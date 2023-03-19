namespace Kwtc.ErrorMonitoring.Domain.Models.ErrorReport;

using Common;

public class ErrorReport : Auditable
{
    public string? AppId { get; set; }
    public Exception? OriginalException { get; set; }
}
