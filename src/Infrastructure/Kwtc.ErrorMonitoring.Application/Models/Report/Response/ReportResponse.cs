namespace Kwtc.ErrorMonitoring.Application.Models.Report.Response;

public class ReportResponse
{
    public DateTime CreatedAt { get; set; }

    public Guid? AppId { get; set; }

    public EventResponse Event { get; set; } = default!;
}
