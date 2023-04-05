namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Transactions;
using Abstractions.Mapping;
using Domain.Report;
using FluentValidation;
using MediatR;
using Models.Report;
using Persistence.Event;
using Persistence.Exception;
using Persistence.Report;
using Persistence.Trace;
using Validators.Report;

public record PersistReportPayloadCommand(ReportPayload Payload, Guid ClientId) : IRequest;

internal sealed class PersistReportPayloadCommandHandler : IRequestHandler<PersistReportPayloadCommand>
{
    private readonly IReportRepository reportRepository;
    private readonly IMapper<ReportPayload, Report> reportMapper;
    private readonly IEventRepository eventRepository;
    private readonly IMapper<EventPayload, Event> eventMapper;
    private readonly IExceptionRepository exceptionRepository;
    private readonly IMapper<ExceptionPayload, Exception> exceptionMapper;
    private readonly ITraceRepository traceRepository;
    private readonly IMapper<TracePayload, Trace> traceMapper;

    public PersistReportPayloadCommandHandler(IReportRepository reportRepository, IMapper<ReportPayload, Report> reportMapper, IEventRepository eventRepository,
        IMapper<EventPayload, Event> eventMapper, IExceptionRepository exceptionRepository, IMapper<ExceptionPayload, Exception> exceptionMapper, ITraceRepository traceRepository,
        IMapper<TracePayload, Trace> traceMapper)
    {
        this.reportRepository = reportRepository;
        this.reportMapper = reportMapper;
        this.eventRepository = eventRepository;
        this.eventMapper = eventMapper;
        this.exceptionRepository = exceptionRepository;
        this.exceptionMapper = exceptionMapper;
        this.traceRepository = traceRepository;
        this.traceMapper = traceMapper;
    }

    public async Task Handle(PersistReportPayloadCommand request, CancellationToken cancellationToken)
    {
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var report = this.reportMapper.MapNew(request.Payload);
        report.ClientId = request.ClientId;
        await new PersistReportValidator().ValidateAndThrowAsync(report, cancellationToken);
        var persistedReport = await this.reportRepository.AddAsync(report, cancellationToken);

        var @event = this.eventMapper.MapNew(request.Payload.Event);
        @event.ReportId = persistedReport.Id;
        await new PersistEventValidator().ValidateAndThrowAsync(@event, cancellationToken);
        var persistedEvent = await this.eventRepository.AddAsync(@event, cancellationToken);

        foreach (var exceptionPayload in request.Payload.Event.Exceptions)
        {
            var exception = this.exceptionMapper.MapNew(exceptionPayload);
            exception.EventId = persistedEvent.Id;
            await new PersistExceptionValidator().ValidateAndThrowAsync(exception, cancellationToken);
            var persistedException = await this.exceptionRepository.AddAsync(exception, cancellationToken);

            // Populate trace with exception id and validate
            var traceLines = new List<Trace>();
            foreach (var traceLinePayload in exceptionPayload.Trace)
            {
                var traceLine = this.traceMapper.MapNew(traceLinePayload);
                traceLine.ExceptionId = persistedException.Id;
                await new PersistTraceValidator().ValidateAndThrowAsync(traceLine, cancellationToken);
                traceLines.Add(traceLine);
            }

            await this.traceRepository.AddBulkAsync(traceLines, cancellationToken);
        }

        transactionScope.Complete();
    }
}
