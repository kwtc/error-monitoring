namespace Kwtc.ErrorMonitoring.Application.Models.Report.Payload;

using System.Text.Json.Serialization;

public class ReportPayload
{
    [JsonPropertyName("appId")]
    public string ApplicationId { get; set; } = default!;
    
    [JsonPropertyName("event")]
    public EventPayload EventPayload { get; set; } = default!;
}
