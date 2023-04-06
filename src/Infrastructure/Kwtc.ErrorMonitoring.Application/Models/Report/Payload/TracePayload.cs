namespace Kwtc.ErrorMonitoring.Application.Models.Report.Payload;

using System.Text.Json.Serialization;

public class TracePayload
{
    [JsonPropertyName("file")]
    public string File { get; set; } = default!;
    
    [JsonPropertyName("lineNumber")]
    public int LineNumber { get; set; }
    
    [JsonPropertyName("method")]
    public string Method { get; set; } = default!;  
}
