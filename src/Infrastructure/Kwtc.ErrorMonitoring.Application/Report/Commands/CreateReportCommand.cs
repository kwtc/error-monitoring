namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Text.Json;
using Abstractions.Mapping;
using Domain.Report;
using MediatR;
using Models.Report.Payload;

public record CreateReportCommand(string JsonContent, Guid ClientId) : IRequest<Report>;

internal sealed class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, Report>
{
    private readonly IMapper<EventPayload, Event> eventMapper;
    private readonly IMapper<ExceptionPayload, Exception> exceptionMapper;
    private readonly IMapper<TracePayload, Trace> traceMapper;

    public CreateReportCommandHandler(IMapper<EventPayload, Event> eventMapper, IMapper<ExceptionPayload, Exception> exceptionMapper, IMapper<TracePayload, Trace> traceMapper)
    {
        this.eventMapper = eventMapper;
        this.exceptionMapper = exceptionMapper;
        this.traceMapper = traceMapper;
    }

    public Task<Report> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var payload = JsonSerializer.Deserialize<ReportPayload>(request.JsonContent)
                      ?? throw new InvalidOperationException("Unable to deserialize payload.");

        var report = new Report(request.ClientId);
        var @event = this.eventMapper.MapNew(payload.EventPayload);

        foreach (var exceptionPayload in payload.EventPayload.Exceptions)
        {
            var exception = this.exceptionMapper.MapNew(exceptionPayload);
            foreach (var trace in exceptionPayload.Trace)
            {
                exception.TraceLines.Add(this.traceMapper.MapNew(trace));
            }

            @event.Exceptions.Add(exception);
        }

        report.Event = @event;

        return Task.FromResult(report);
    }
}
