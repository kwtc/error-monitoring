using Kwtc.ErrorMonitoring.Domain.Event;

namespace Kwtc.ErrorMonitoring.Application.Models.Response;

public class EventResponse
{
    public Severity Severity { get; set; }

    public bool IsHandled { get; set; }
}
