using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class API2Controller : ControllerBase
{
    private readonly ILogger<API2Controller> _logger;

    public API2Controller(ILogger<API2Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRecord")]
    public String Get()
    {
        return "API 2 - Record";
    }
}
