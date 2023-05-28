namespace Kwtc.ErrorMonitoring.Application.Reports.Events;

using Domain.Event;
using MediatR;

public record NewEvent(Event Event) : INotification;
