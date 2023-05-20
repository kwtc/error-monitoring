namespace Kwtc.ErrorMonitoring.Application.Report.Commands;

using System.Text.Json;
using Abstractions.Mapping;
using Domain.Report;
using MediatR;
using Models.Report.Payload;

public record MapReportPayloadCommand(string JsonContent, Guid ClientId) : IRequest<Report>;

internal sealed class MapReportPayloadCommandHandler : IRequestHandler<MapReportPayloadCommand, Report>
{
    private readonly IMapper<ReportPayload, Report> reportMapper;

    public MapReportPayloadCommandHandler(IMapper<ReportPayload, Report> reportMapper)
    {
        this.reportMapper = reportMapper;
    }

    public Task<Report> Handle(MapReportPayloadCommand request, CancellationToken cancellationToken)
    {
        var payload = JsonSerializer.Deserialize<ReportPayload>(request.JsonContent)
                      ?? throw new InvalidOperationException("Unable to deserialize payload.");

        var report = this.reportMapper.MapNew(payload);
        report.ClientId = request.ClientId;

        return Task.FromResult(report);
    }
}
