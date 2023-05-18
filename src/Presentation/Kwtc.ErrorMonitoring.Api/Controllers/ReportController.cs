namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Report.Commands;
using Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ReportController : AuthorizedControllerBase
{
    private readonly IMediator mediator;

    public ReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("report/notify")]
    [Authorization]
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(content))
        {
            return this.BadRequest();
        }

        var client = this.GetAuthorizedClient();
        var payload = await this.mediator.Send(new DeserializeReportPayloadCommand(content), cancellationToken);
        await this.mediator.Send(new PersistReportPayloadCommand(payload, client.Id), cancellationToken);

        return this.Ok();
    }
}
