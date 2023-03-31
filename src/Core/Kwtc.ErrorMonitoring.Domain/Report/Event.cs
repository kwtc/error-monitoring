namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Event
{
    public List<Exception> Exceptions { get; set; } = new();

    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }
}
