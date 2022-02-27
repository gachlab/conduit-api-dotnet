using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace conduit_api_dotnet.Articles;

[ApiController]
[Route("articles")]
public class AspNetController : ControllerBase
{
    private readonly UseCases useCases;

    public AspNetController(UseCases useCases)
    {
        this.useCases = useCases;

    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<MultipleArticlesResponse>> List()
    {
        var articles = await useCases.list();
        return Ok(new MultipleArticlesResponse() { articles = articles, articlesCount = articles.Count() });
    }

    [HttpGet(Name = "ArticlesDetails")]
    [Route("{id}")]
    public async Task<ActionResult<SingleArticleResponse>> Details([FromRoute] string id)
    {
        try
        {
            var article = await useCases.details(id);
            return Ok(new SingleArticleResponse() { article = article });

        }
        catch (Exception e)
        {
            if (e.Message == "not-found")
            {
                return NotFound();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Create([FromBody] SingleArticleRequest request)
    {
        if (request.article != null && request.article.title != null)
        {
            try
            {
                var article = await useCases.create(new Article()
                {
                    slug = request.article.title.Replace(" ", "-").ToLower(),
                    title = request.article.title != null ? request.article.title : "",
                    body = request.article.body != null ? request.article.body : "",
                    tagList = request.article.tagList != null ? request.article.tagList : new List<string>(),
                });
                return CreatedAtAction(nameof(Details), new { id = article }, new {});

            }
            catch (Exception e)
            {
                if (e.Message == "conflict")
                {
                    return Conflict();
                }
                else if (e.Message == "conflict")
                {
                    return BadRequest();
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }
        else
        {
            return BadRequest();
        }
    }


    public class MultipleArticlesResponse
    {
        public IEnumerable<Article>? articles { get; set; }
        public int articlesCount { get; set; }
    }

    public class SingleArticleResponse
    {
        public Article? article { get; set; }
    }

    public class ArticleRequest
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? body { get; set; }
        public IList<string>? tagList { get; set; }
    }

    public class SingleArticleRequest
    {
        public ArticleRequest? article { get; set; }
    }
}
