namespace Kwtc.ErrorMonitoring.Api.Controllers;

using System.Text.Json;
using Application.Models.Payload;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("report")]
public class ReportController : ControllerBase
{
    private readonly ILogger<ReportController> logger;
    private readonly IMediator mediator;

    public ReportController(ILogger<ReportController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("notify")]
    public IActionResult GetNotifications(CancellationToken cancellationToken = default)
    {
        return Ok(new { Message = "Yiha baby!" });
    }

    [HttpPost]
    [Route("notify")]
    public async Task<IActionResult> Notify([FromBody] string content, CancellationToken cancellationToken = default)
    {
        ReportPayload? payload;
        try
        {
            payload = JsonSerializer.Deserialize<ReportPayload>(content);
        }
        catch (System.Exception e)
        {
            // TODO: handle this better!
            return BadRequest(e.Message);
        }

        // TODO: Validate user based on an ApiKey (Could be handled/added as an attribute)

        // logger.LogInformation($"Error report received: {payload.OriginalException?.Message}");
        //
        // await this.mediator.Send(new RegisterErrorReportCommand(payload), cancellationToken);
        
        return Ok();
    }
}
