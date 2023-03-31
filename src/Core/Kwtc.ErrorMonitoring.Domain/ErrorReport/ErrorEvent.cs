namespace Kwtc.ErrorMonitoring.Domain.ErrorReport;

public class ErrorEvent
{
    public List<Exception> Exceptions { get; set; } = new();

    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }
}
