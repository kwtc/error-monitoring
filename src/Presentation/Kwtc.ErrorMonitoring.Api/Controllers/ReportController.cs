namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.Reports.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("report")]
public class ReportController : ControllerBase
{
    private readonly IMediator mediator;

    public ReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("notify")]
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

        // Validate and convert the payload to domain model
        var errorReport = await this.mediator.Send(new ValidateAndConvertReportPayloadCommand(content), cancellationToken);
        await this.mediator.Send(new PersistReportCommand(client.Id, errorReport), cancellationToken);

        return Ok();
    }
}
