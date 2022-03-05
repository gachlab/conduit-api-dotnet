using Microsoft.AspNetCore.Mvc;

namespace Conduit.Users;

[ApiController]
public class AspNetController : ControllerBase
{
    private readonly UseCases useCases;

    public AspNetController(UseCases useCases)
    {
        this.useCases = useCases;
    }
}