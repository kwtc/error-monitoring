namespace Kwtc.ErrorMonitoring.Api.Controllers.v1;

using Application.Report.Queries;
using Attributes;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
public class EventController : ApiControllerBase
{
    [HttpGet]
    [Route("events")]
    [Authorization]
    public async Task<IActionResult> GetEvents(CancellationToken cancellationToken = default)
    {
        var client = this.GetAuthorizedClient();

        var response = await this.Mediator.Send(new GetReportResponseByClientIdAndAppIdQuery(client.Id, null), cancellationToken);

        return this.Ok(response);
    }
}
