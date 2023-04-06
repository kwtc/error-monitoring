namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application;
using Application.Report.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class EventController : ControllerBase
{
    private readonly IMediator mediator;

    public EventController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("events")]
    public async Task<IActionResult> GetEvents(CancellationToken cancellationToken = default)
    {
        // TODO: Get actual client id from auth provider/service
        var clientId = DevelopmentConstants.DummyClientId;

        var response = await this.mediator.Send(new GetReportResponseByClientIdAndAppIdQuery(clientId, null), cancellationToken);

        return this.Ok(response);
    }
}
