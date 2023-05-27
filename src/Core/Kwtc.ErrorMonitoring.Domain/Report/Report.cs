namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Report
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }

    public Guid ApplicationId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Event Event { get; set; } = default!;

    public Report()
    {
    }

    public Report(Guid clientId)
    {
        this.ClientId = clientId;
    }
}
