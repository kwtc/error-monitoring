namespace Kwtc.ErrorMonitoring.Application.Models.Payload;

using System.Text.Json.Serialization;

public class Trace
{
    [JsonPropertyName("file")]
    public string File { get; set; } = default!;
    
    [JsonPropertyName("lineNumber")]
    public int LineNumber { get; set; }
    
    [JsonPropertyName("method")]
    public string Method { get; set; } = default!;  
}
