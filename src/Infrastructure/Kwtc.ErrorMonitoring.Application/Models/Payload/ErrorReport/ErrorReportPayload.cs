namespace Kwtc.ErrorMonitoring.Application.Models.Payload.ErrorReport;

using System.Text.Json.Serialization;

public class ErrorReportPayload
{
    [JsonPropertyName("event")]
    public ErrorEventPayload Event { get; set; } = default!;
}
