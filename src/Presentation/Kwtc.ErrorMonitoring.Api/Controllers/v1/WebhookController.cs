using Kwtc.ErrorMonitoring.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Kwtc.ErrorMonitoring.Api.Controllers.v1;

[ApiVersion("1.0")]
public class WebhookController : ApiControllerBase
{
    [HttpPost]
    [Authorization]
    [Route("webhook")]
    public async Task<IActionResult> AddWebhook(CancellationToken cancellationToken = default)
    {
        var payload = await this.GetBodyAsStringAsync(cancellationToken);
        var client = this.GetAuthorizedClient();

        // TODO: Implement actual add webhook logic.

        return this.Ok();
    }
}
