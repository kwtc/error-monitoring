namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Report.Queries;
using Attributes;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/events")]
public class EventController : ApiControllerBase
{
    [HttpGet]
    [Route("")]
    [Authorization]
    public async Task<IActionResult> GetEvents(CancellationToken cancellationToken = default)
    {
        var client = this.GetAuthorizedClient();

        var response = await this.Mediator.Send(new GetReportResponseByClientIdAndAppIdQuery(client.Id, null), cancellationToken);

        return this.Ok(response);
    }
}
