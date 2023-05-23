namespace Kwtc.ErrorMonitoring.Api.Controllers.v1;

using Application.Reports.Commands;
using Attributes;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
public sealed class ReportController : ApiControllerBase
{
    [HttpPost]
    [Route("report/notify")]
    [Authorization]
    public async Task<IActionResult> Notify(CancellationToken cancellationToken = default)
    {
        var payload = await this.GetBodyAsStringAsync(cancellationToken);
        var client = this.GetAuthorizedClient();
        var report = await this.Mediator.Send(new MapReportPayloadJsonCommand(payload, client.Id), cancellationToken);
        await this.Mediator.Send(new PersistReportCommand(report), cancellationToken);

        return this.Ok();
    }
}
