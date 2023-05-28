namespace Kwtc.ErrorMonitoring.Application.Notification;

using Domain.Event;
using MediatR;

public record NewEventNotification(Event Event) : INotification;
