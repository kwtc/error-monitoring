namespace Kwtc.ErrorMonitoring.Application.WebHooks.Handlers;

using MediatR;
using Notification;

public class NewEventNotificationHandler : INotificationHandler<NewEventNotification>
{
    public Task Handle(NewEventNotification eventNotification, CancellationToken cancellationToken)
    {
        // TODO: 
        throw new NotImplementedException();
    }
}
