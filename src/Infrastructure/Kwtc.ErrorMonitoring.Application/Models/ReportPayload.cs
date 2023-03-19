namespace Kwtc.ErrorMonitoring.Application.Models;

[Serializable]
public class ReportPayload
{
    public string? AppId { get; set; }
    public Exception? OriginalException { get; set; }
}
