namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Domain.Models;
using Microsoft.AspNetCore.Mvc;

[Route("error")]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        this.logger = logger;
    }

    [HttpPost]
    [Route("notify")]
    public IActionResult Notify(Report? report)
    {
        logger.LogInformation($"Error report received: {report?.OriginalException?.Message}");
        
        return Ok();
    }
}
