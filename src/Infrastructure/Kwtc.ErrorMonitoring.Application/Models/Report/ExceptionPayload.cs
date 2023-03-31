namespace Kwtc.ErrorMonitoring.Application.Models.Report;

using System.Text.Json.Serialization;

public class ExceptionPayload
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("message")]
    public string Message { get; set; } = default!;

    [JsonPropertyName("trace")]
    public List<TracePayload> Trace { get; set; } = new();
}
