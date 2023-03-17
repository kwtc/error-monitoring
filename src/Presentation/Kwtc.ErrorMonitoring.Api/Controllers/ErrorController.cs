namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Reports.Commands;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("error")]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> logger;
    private readonly IMediator mediator;

    public ErrorController(ILogger<ErrorController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("notify")]
    public async Task<IActionResult> Notify(Report? report)
    {
        if (report == null)
        {
            return BadRequest();
        }
        
        logger.LogInformation($"Error report received: {report.OriginalException?.Message}");

        await this.mediator.Send(new SaveErrorReportCommand(report));
        
        return Ok();
    }
}
