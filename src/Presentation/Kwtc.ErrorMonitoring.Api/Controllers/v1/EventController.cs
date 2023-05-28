namespace Kwtc.ErrorMonitoring.Api.Controllers.v1;

using Application.Reports.Commands;
using Application.Reports.Queries;
using Attributes;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
public sealed class EventController : ApiControllerBase
{
    [HttpGet]
    [Route("events")]
    [Authorization]
    public async Task<IActionResult> GetEvents(Guid appId, CancellationToken cancellationToken = default)
    {
        var client = this.GetAuthorizedClient();

        var response = await this.Mediator.Send(new GetReportResponseByClientIdAndAppIdQuery(client.Id, appId), cancellationToken);

        return this.Ok(response);
    }

    [HttpPost]
    [Route("events")]
    [Authorization]
    public async Task<IActionResult> AddEvent(CancellationToken cancellationToken = default)
    {
        // TODO: Remove all references to a report and just use an event

        var payload = await this.GetBodyAsStringAsync(cancellationToken);
        var client = this.GetAuthorizedClient();
        var report = await this.Mediator.Send(new MapReportPayloadJsonCommand(payload, client.Id), cancellationToken);
        await this.Mediator.Send(new PersistReportCommand(report), cancellationToken);

        return this.Ok();
    }
}
