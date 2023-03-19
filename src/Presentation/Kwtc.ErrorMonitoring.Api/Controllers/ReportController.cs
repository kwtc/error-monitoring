namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.ErrorReports.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("report")]
public class ReportController : ControllerBase
{
    private readonly ILogger<ReportController> logger;
    private readonly IMediator mediator;

    public ReportController(ILogger<ReportController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("notify")]
    public async Task<IActionResult> Notify(ReportPayload? payload, CancellationToken cancellationToken)
    {
        if (payload == null)
        {
            return BadRequest();
        }


        // TODO: Validate user based on an ApiKey (Could be handled/added as an attribute)

        logger.LogInformation($"Error report received: {payload.OriginalException?.Message}");

        await this.mediator.Send(new RegisterErrorReportCommand(payload), cancellationToken);

        return Ok();
    }
}
