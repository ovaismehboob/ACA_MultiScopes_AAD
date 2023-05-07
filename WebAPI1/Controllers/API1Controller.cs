using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class API1Controller : ControllerBase
{
    private readonly ILogger<API1Controller> _logger;

    public API1Controller(ILogger<API1Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRecord")]
    public String Get()
    {
        return "API 1 - Record"; 
    }
}
