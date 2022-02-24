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
    [HttpGet(Name = "ListArticles")]
    public async Task<ActionResult<MultipleArticlesResponse>> List()
    {
        var articles = await useCases.list();
        return Ok(new MultipleArticlesResponse() { articles = articles, articlesCount = articles.Count() });
    }

    public class MultipleArticlesResponse
    {
        public IEnumerable<Article>? articles { get; set; }
        public int articlesCount { get; set; }
    }
}
