namespace Kwtc.ErrorMonitoring.Application.Models.Report;

using System.Text.Json.Serialization;

public class EventPayload
{
    [JsonPropertyName("exceptions")]
    public List<ExceptionPayload> Exceptions { get; set; } = new();

    [JsonPropertyName("severity")]
    public string Severity { get; set; } = default!;

    [JsonPropertyName("isHandled")]
    public bool IsHandled { get; set; }
}
