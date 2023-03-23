namespace Kwtc.ErrorMonitoring.Domain.ErrorReport;

using Common;

public class ErrorReport : Auditable
{
    public Guid Id { get; set; }
    public string? AppId { get; set; }
    public Severity Severity { get; set; }
    public Exception? OriginalException { get; set; }
}
