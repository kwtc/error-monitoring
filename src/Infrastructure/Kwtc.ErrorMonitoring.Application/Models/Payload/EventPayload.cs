using System.Text.Json.Serialization;

namespace Kwtc.ErrorMonitoring.Application.Models.Payload;

public class EventPayload
{
    [JsonPropertyName("applicationId")]
    public string ApplicationId { get; set; } = default!;

    [JsonPropertyName("exceptionType")]
    public string ExceptionType { get; set; } = default!;

    [JsonPropertyName("exceptions")]
    public List<ExceptionPayload> Exceptions { get; set; } = new();

    [JsonPropertyName("severity")]
    public string Severity { get; set; } = default!;

    [JsonPropertyName("isHandled")]
    public bool IsHandled { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}
