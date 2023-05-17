namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Report.Commands;
using Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ReportController : ControllerBase
{
    private readonly IMediator mediator;

    public ReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("report/notify")]
    [ApiAuthorization]
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(content))
        {
            return this.BadRequest();
        }

        var client = AuthorizationHelper.GetClient(Request);
        var payload = await this.mediator.Send(new DeserializeReportPayloadCommand(content), cancellationToken);
        await this.mediator.Send(new PersistReportPayloadCommand(payload, client.Id), cancellationToken);

        return this.Ok();
    }
    
    [HttpGet]
    [Route("report/test")]
    [ApiAuthorization]
    public IActionResult Test(CancellationToken cancellationToken = default)
    {
        var client = AuthorizationHelper.GetClient(Request);

        return this.Ok();
    }
}
