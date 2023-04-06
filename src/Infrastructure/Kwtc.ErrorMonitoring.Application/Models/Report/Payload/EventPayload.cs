namespace Kwtc.ErrorMonitoring.Application.Models.Report.Payload;

using System.Text.Json.Serialization;

public class EventPayload
{
    [JsonPropertyName("appIdentifier")]
    public string AppIdentifier { get; set; } = default!;

    [JsonPropertyName("exceptionType")]
    public string ExceptionType { get; set; } = default!;

    [JsonPropertyName("exceptionMessage")]
    public string ExceptionMessage { get; set; } = default!;

    [JsonPropertyName("exceptions")]
    public List<ExceptionPayload> Exceptions { get; set; } = default!;

    [JsonPropertyName("severity")]
    public string Severity { get; set; } = default!;

    [JsonPropertyName("isHandled")]
    public bool IsHandled { get; set; }
}
