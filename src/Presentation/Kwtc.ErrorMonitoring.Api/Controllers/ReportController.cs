namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Report.Commands;
using Attributes;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/report")]
public class ReportController : ApiControllerBase
{
    [HttpPost]
    [Route("notify")]
    [Authorization]
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(content))
        {
            return this.BadRequest();
        }

        var client = this.GetAuthorizedClient();
        var payload = await this.Mediator.Send(new DeserializeReportPayloadCommand(content), cancellationToken);
        await this.Mediator.Send(new PersistReportPayloadCommand(payload, client.Id), cancellationToken);

        return this.Ok();
    }
}
