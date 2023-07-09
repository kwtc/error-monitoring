using Kwtc.ErrorMonitoring.Application.Notification;
using MediatR;

namespace Kwtc.ErrorMonitoring.Application.WebHooks.Handlers;

public class NewEventNotificationHandler : INotificationHandler<NewEventNotification>
{
    public Task Handle(NewEventNotification eventNotification, CancellationToken cancellationToken)
    {
        // TODO: 
        throw new NotImplementedException();
    }
}
