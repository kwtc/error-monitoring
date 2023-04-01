namespace Kwtc.ErrorMonitoring.Application.Reports.Commands;

using System.Transactions;
using Domain.Report;
using FluentValidation;
using MediatR;
using Persistence.Event;
using Persistence.Exception;
using Persistence.Report;
using Persistence.Trace;
using Validators.Report;

public record PersistReportCommand(Report Report) : IRequest<Report>;

internal sealed class PersistReportCommandHandler : IRequestHandler<PersistReportCommand, Report>
{
    private readonly IReportRepository reportRepository;
    private readonly IEventRepository eventRepository;
    private readonly IExceptionRepository exceptionRepository;
    private readonly ITraceRepository traceRepository;

    public PersistReportCommandHandler(IReportRepository reportRepository, IEventRepository eventRepository, IExceptionRepository exceptionRepository,
        ITraceRepository traceRepository)
    {
        this.reportRepository = reportRepository;
        this.eventRepository = eventRepository;
        this.exceptionRepository = exceptionRepository;
        this.traceRepository = traceRepository;
    }

    public async Task<Report> Handle(PersistReportCommand request, CancellationToken cancellationToken)
    {
        using var scope = new TransactionScope();
        
        await new PersistReportValidator().ValidateAndThrowAsync(request.Report, cancellationToken);
        var report = await this.reportRepository.AddAsync(request.Report, cancellationToken);

        report.Event.ReportId = report.Id;
        await new PersistEventValidator().ValidateAndThrowAsync(report.Event, cancellationToken);
        report.Event = await this.eventRepository.AddAsync(report.Event, cancellationToken);

        foreach (var exception in report.Event.Exceptions)
        {
            exception.EventId = report.Event.Id!.Value;
            await new PersistExceptionValidator().ValidateAndThrowAsync(exception, cancellationToken);
            var persistedException = await this.exceptionRepository.AddAsync(exception, cancellationToken);
            
            foreach (var trace in persistedException.Trace)
            {
                trace.ExceptionId = persistedException.Id!.Value;
                await new PersistTraceValidator().ValidateAndThrowAsync(trace, cancellationToken);
            }

            exception.Trace = await this.traceRepository.AddBulkAsync(persistedException.Trace, cancellationToken);
        }

        scope.Complete();

        return report;
    }
}
