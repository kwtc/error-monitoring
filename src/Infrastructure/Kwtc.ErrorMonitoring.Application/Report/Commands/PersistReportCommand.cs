namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Transactions;
using Domain.Report;
using MediatR;
using Persistence.Event;
using Persistence.Exception;
using Persistence.Report;
using Persistence.Trace;

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

        var persistedReport = await this.reportRepository.AddAsync(request.Report, cancellationToken);

        request.Report.Event.ReportId = persistedReport.Id;
        var persistedEvent = await this.eventRepository.AddAsync(request.Report.Event, cancellationToken);
        foreach (var exception in request.Report.Event.Exceptions)
        {
            exception.EventId = persistedEvent.Id;
            var persistedException = await this.exceptionRepository.AddAsync(exception, cancellationToken);
            foreach (var traceLine in exception.TraceLines)
            {
                traceLine.ExceptionId = persistedException.Id;
            }

            await this.traceRepository.AddBulkAsync(exception.TraceLines, cancellationToken);
        }

        transactionScope.Complete();
    }
}
