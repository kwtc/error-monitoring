using Kwtc.ErrorMonitoring.Domain.Event;
using MediatR;

namespace Kwtc.ErrorMonitoring.Application.Notification;

public record NewEventNotification(Event Event) : INotification;
