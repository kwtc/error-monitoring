namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Report
{
    public Guid ClientId { get; set; }

    public string? AppId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Event Event { get; set; } = default!;
}
