namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Transactions;
using Domain.Report;
using FluentValidation;
using MediatR;
using Persistence.Event;
using Persistence.Exception;
using Persistence.Report;
using Persistence.Trace;
using Validators.Report;

public record PersistReportCommand(Report Report) : IRequest;

internal sealed class PersistReportCommandHandler : IRequestHandler<PersistReportCommand>
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

    public async Task Handle(PersistReportCommand request, CancellationToken cancellationToken)
    {
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        // Unable to chain validators in report validator since we require ids to be set
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

            // Populate trace with exception id and validate
            foreach (var trace in persistedException.Trace)
            {
                trace.ExceptionId = persistedException.Id!.Value;
                await new PersistTraceValidator().ValidateAndThrowAsync(trace, cancellationToken);
            }

            await this.traceRepository.AddBulkAsync(persistedException.Trace, cancellationToken);
        }

        transactionScope.Complete();
    }
}
