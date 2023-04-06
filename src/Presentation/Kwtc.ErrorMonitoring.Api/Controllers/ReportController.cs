namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Report.Commands;
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
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(content))
        {
            return this.BadRequest();
        }

        if (!Request.Headers.TryGetValue("x-api-key", out var apiKey) ||
            !Guid.TryParse(apiKey, out var guidApiKey))
        {
            return this.BadRequest();
        }

        var client = await this.mediator.Send(new ValidateApiKeyCommand(guidApiKey), cancellationToken);
        if (client == null)
        {
            return this.Unauthorized();
        }

        var payload = await this.mediator.Send(new DeserializeReportPayloadCommand(content), cancellationToken);
        await this.mediator.Send(new PersistReportPayloadCommand(payload, client.Id), cancellationToken);

        return this.Ok();
    }
}
