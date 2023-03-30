namespace Kwtc.ErrorMonitoring.Application.Models.Payload.ErrorReport;

using System.Text.Json.Serialization;

public class ErrorReportPayload
{
    [JsonPropertyName("apiKey")]
    public Guid ApiKey { get; set; }

    [JsonPropertyName("event")]
    public ErrorEventPayload Event { get; set; } = default!;
}
