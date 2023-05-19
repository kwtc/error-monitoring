namespace Kwtc.ErrorMonitoring.Api.Controllers.v1;

using Application.Report.Commands;
using Attributes;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
public class ReportController : ApiControllerBase
{
    [HttpPost]
    [Route("report/notify")]
    [Authorization]
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        var client = this.GetAuthorizedClient();
        var report = await this.Mediator.Send(new CreateReportCommand(content, client.Id), cancellationToken);
        await this.Mediator.Send(new PersistReportCommand(report), cancellationToken);

        return this.Ok();
    }
}
