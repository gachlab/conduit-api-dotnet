using Microsoft.AspNetCore.Mvc;

namespace conduit_api_dotnet.Tags;

[ApiController]
[Route("tags")]
public class AspNetController : ControllerBase
{
    private readonly UseCases useCases;

    public AspNetController(UseCases useCases)
    {
        this.useCases = useCases;

    }
    [HttpGet(Name = "ListTags")]
    public async Task<ActionResult<IEnumerable<string>>> List()
    {
        var tags = await useCases.list();
        return Ok(tags.Select(tag => tag.name));
    }

}
