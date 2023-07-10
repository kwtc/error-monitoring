namespace Kwtc.ErrorMonitoring.Domain.Event;

public class Event
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }

    public Guid ApplicationId { get; set; }

    public string ExceptionType { get; set; } = default!;

    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }

    public List<Exception> Exceptions { get; set; } = new();

    public DateTime CreatedAt { get; set; }

    public Dictionary<string, string> Metadata { get; set; } = new();
}
