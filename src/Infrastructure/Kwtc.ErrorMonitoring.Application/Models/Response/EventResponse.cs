namespace Kwtc.ErrorMonitoring.Application.Models.Response;

using Kwtc.ErrorMonitoring.Domain.Event;

public class EventResponse
{
    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }
}
