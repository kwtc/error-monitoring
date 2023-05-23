namespace Kwtc.ErrorMonitoring.Application.WebHooks.Handlers;

using MediatR;
using Reports.Events;

public class NewReportEventHandler : INotificationHandler<NewReportEvent>
{
    public Task Handle(NewReportEvent @event, CancellationToken cancellationToken)
    {
        // TODO: 
        throw new NotImplementedException();
    }
}
