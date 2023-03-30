namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.ErrorReports.Commands;
using Application.ErrorReports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("report")]
public class ErrorReportController : ControllerBase
{
    private readonly IMediator mediator;

    public ErrorReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("notify")]
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        var errorReport = await this.mediator.Send(new ValidateAndConvertErrorReportPayloadCommand(content), cancellationToken);

        // TODO: This should return an actual user/customer id/object to be used when persisting error report
        if (!await this.mediator.Send(new ValidateApiKeyQuery(errorReport.ApiKey), cancellationToken))
        {
            return Unauthorized();
        }

        // await this.mediator.Send(new PersistErrorReportCommand(errorReport), cancellationToken);

        return Ok();
    }
}
