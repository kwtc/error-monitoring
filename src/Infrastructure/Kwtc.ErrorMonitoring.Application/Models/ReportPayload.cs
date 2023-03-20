namespace Kwtc.ErrorMonitoring.Application.Models;

using Domain.ErrorReport;

[Serializable]
public class ReportPayload
{
    public string ApiKey { get; set; } = default!;
    public string? AppId { get; set; }
    public Severity Severity { get; set; }
    public Exception? OriginalException { get; set; }
}
