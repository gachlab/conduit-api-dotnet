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

    [HttpGet]
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

    public class MultipleArticlesResponse
    {
        public IEnumerable<Article>? articles { get; set; }
        public int articlesCount { get; set; }
    }

    public class SingleArticleResponse
    {
        public Article? article { get; set; }
    }
}
