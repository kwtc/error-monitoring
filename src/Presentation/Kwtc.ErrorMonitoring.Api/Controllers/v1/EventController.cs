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

        var response = await this.Mediator.Send(new GetEventsByClientIdAndAppIdQuery(client.Id, appId), cancellationToken);

        return this.Ok(response);
    }

    [HttpPost]
    [Route("events")]
    [Authorization]
    public async Task<IActionResult> AddEvent(CancellationToken cancellationToken = default)
    {
        var payload = await this.GetBodyAsStringAsync(cancellationToken);
        var @event = await this.Mediator.Send(new MapEventPayloadJsonCommand(payload), cancellationToken);
        @event.ClientId = this.GetAuthorizedClient().Id;
        await this.Mediator.Send(new PersistEventCommand(@event), cancellationToken);

        return this.Ok();
    }
}
