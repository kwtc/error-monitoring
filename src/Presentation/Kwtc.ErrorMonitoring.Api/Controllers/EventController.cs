namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Report.Queries;
using Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class EventController : AuthorizedControllerBase
{
    private readonly IMediator mediator;

    public EventController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("events")]
    [Authorization]
    public async Task<IActionResult> GetEvents(CancellationToken cancellationToken = default)
    {
        var client = this.GetAuthorizedClient();

        var response = await this.mediator.Send(new GetReportResponseByClientIdAndAppIdQuery(client.Id, null), cancellationToken);

        return this.Ok(response);
    }
}
