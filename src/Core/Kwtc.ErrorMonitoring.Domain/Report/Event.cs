namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Event
{
    public Guid? Id { get; set; }
    
    public Guid ReportId { get; set; }

    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }
    
    public List<Exception> Exceptions { get; set; } = new();
}
