namespace Kwtc.ErrorMonitoring.Domain.ErrorReport;

using Common;

public class ErrorReport : Auditable
{
    public Guid Id { get; set; }
    public Guid ApiKey { get; set; }
    public Severity Severity { get; set; }
    public Exception? OriginalException { get; set; }
}
