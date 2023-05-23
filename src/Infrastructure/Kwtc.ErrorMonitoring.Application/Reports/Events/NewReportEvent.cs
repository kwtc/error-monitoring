namespace Kwtc.ErrorMonitoring.Application.Reports.Events;

using Domain.Report;
using MediatR;

public record NewReportEvent(Report Report) : INotification;
