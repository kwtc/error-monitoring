namespace Kwtc.ErrorMonitoring.Api.Controllers.v1;

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
}
