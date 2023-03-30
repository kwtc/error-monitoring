namespace Kwtc.ErrorMonitoring.Application.Models.Payload;

using System.Text.Json.Serialization;

public class ReportPayload
{
    // [JsonPropertyName("exceptions")]
    // public List<Exception> Exceptions { get; set; } = default!;
    //
    // [JsonPropertyName("severity")]
    // public string Severity { get; set; } = default!;
    
    [JsonPropertyName("isHandled")]
    public bool IsHandled { get; set; }
}
