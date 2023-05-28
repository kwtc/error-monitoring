namespace Kwtc.ErrorMonitoring.Application.WebHooks.Handlers;

using MediatR;
using Reports.Events;

public class NewReportEventHandler : INotificationHandler<NewEvent>
{
    public Task Handle(NewEvent @event, CancellationToken cancellationToken)
    {
        // TODO: 
        throw new NotImplementedException();
    }
}
