namespace Kwtc.ErrorMonitoring.Application.Models.Payload.ErrorReport;

using System.Text.Json.Serialization;

public class ErrorEventPayload
{
    [JsonPropertyName("exceptions")]
    public List<Exception> Exceptions { get; set; } = new();

    [JsonPropertyName("severity")]
    public string Severity { get; set; } = default!;

    [JsonPropertyName("isHandled")]
    public bool IsHandled { get; set; }
}
