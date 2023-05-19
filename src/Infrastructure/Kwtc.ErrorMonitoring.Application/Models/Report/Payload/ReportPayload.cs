namespace Kwtc.ErrorMonitoring.Application.Models.Report.Payload;

using System.Text.Json.Serialization;

public class ReportPayload
{
    [JsonPropertyName("event")]
    public EventPayload EventPayload { get; set; } = default!;
}
