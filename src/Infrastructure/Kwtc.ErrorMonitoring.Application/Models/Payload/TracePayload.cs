using System.Text.Json.Serialization;

namespace Kwtc.ErrorMonitoring.Application.Models.Payload;

public class TracePayload
{
    [JsonPropertyName("file")]
    public string File { get; set; } = default!;
    
    [JsonPropertyName("lineNumber")]
    public int LineNumber { get; set; }
    
    [JsonPropertyName("method")]
    public string Method { get; set; } = default!;  
}
