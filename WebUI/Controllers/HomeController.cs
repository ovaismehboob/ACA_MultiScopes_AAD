using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using WebUI.Models;

namespace WebUI.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IDownstreamWebApi _downstreamWebApi;

    public HomeController(ILogger<HomeController> logger,
                            IDownstreamWebApi downstreamWebApi)
    {
            _logger = logger;
        _downstreamWebApi = downstreamWebApi;
    }

    [AuthorizeForScopes(ScopeKeySection = "API1:Scopes")]
    public async Task<IActionResult> Index()
    {
        using var response = await _downstreamWebApi.CallWebApiForUserAsync("API1").ConfigureAwait(false);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var apiResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ViewData["ApiResult"] = apiResult;
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}: {error}");
        }
        return View();
    }

    [AuthorizeForScopes(ScopeKeySection = "API2:Scopes")]
    public async Task<IActionResult> Privacy()
    {
        using var response = await _downstreamWebApi.CallWebApiForUserAsync("API2").ConfigureAwait(false);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var apiResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ViewData["ApiResult"] = apiResult;
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}: {error}");
        }
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
