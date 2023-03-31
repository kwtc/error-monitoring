namespace Kwtc.ErrorMonitoring.Api.Controllers;

using Application.ErrorReports.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("report")]
public class ErrorReportController : ControllerBase
{
    private readonly IMediator mediator;

    public ErrorReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("notify")]
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        // Verify that the request contains an api key of the correct format
        if (!Request.Headers.TryGetValue("x-api-key", out var apiKey) ||
            string.IsNullOrEmpty(apiKey) ||
            !Guid.TryParse(apiKey, out var guidApiKey))
        {
            return this.BadRequest();
        }

        // Validate the api key
        var client = await this.mediator.Send(new ValidateApiKeyCommand(guidApiKey), cancellationToken);
        if (client == null)
        {
            return this.Unauthorized();
        }

        // Validate and convert the payload to domain model
        var errorReport = await this.mediator.Send(new ValidateAndConvertErrorReportPayloadCommand(content), cancellationToken);
        await this.mediator.Send(new PersistErrorReportCommand(client.Id, errorReport), cancellationToken);

        return Ok();
    }
}
