namespace Kwtc.ErrorMonitoring.Application.Models.Report.Response;

using Domain.Event;

public class EventResponse
{
    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }
}
