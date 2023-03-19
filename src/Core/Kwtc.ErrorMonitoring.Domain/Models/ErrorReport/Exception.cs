namespace Kwtc.ErrorMonitoring.Domain.Models.ErrorReport;

public class Exception
{
    public string? Message { get; set; }
    public string? Source { get; set; }
    public string? StackTrace { get; set; }
    public Exception? InnerException { get; set; }
}
