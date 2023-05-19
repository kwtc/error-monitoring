namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Event
{
    public Guid Id { get; set; }

    public Guid ReportId { get; set; }

    public string AppIdentifier { get; set; } = default!;

    public string ExceptionType { get; set; } = default!;

    public string ExceptionMessage { get; set; } = default!;

    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }

    public List<Exception> Exceptions { get; set; } = new();
}
