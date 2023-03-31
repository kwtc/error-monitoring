namespace Kwtc.ErrorMonitoring.Application.Models.Report;

using System.Text.Json.Serialization;

public class ReportPayload
{
    [JsonPropertyName("event")]
    public EventPayload Event { get; set; } = default!;
}
