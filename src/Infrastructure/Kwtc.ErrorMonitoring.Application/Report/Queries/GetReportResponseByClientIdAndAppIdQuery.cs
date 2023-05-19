namespace Kwtc.ErrorMonitoring.Application.Report.Queries;

using Event.Queries;
using MediatR;
using Models.Report.Response;
using Persistence.Report;

public record GetReportResponseByClientIdAndAppIdQuery(Guid ClientId, Guid? AppId) : IRequest<ReportsResponse>;

internal sealed class GetReportResponseByClientAndAppIdsQueryHandler : IRequestHandler<GetReportResponseByClientIdAndAppIdQuery, ReportsResponse>
{
    private readonly IMediator mediator;
    private readonly IReportRepository reportRepository;

    public GetReportResponseByClientAndAppIdsQueryHandler(IMediator mediator, IReportRepository reportRepository)
    {
        this.mediator = mediator;
        this.reportRepository = reportRepository;
    }

    public async Task<ReportsResponse> Handle(GetReportResponseByClientIdAndAppIdQuery request, CancellationToken cancellationToken)
    {
        var result = new ReportsResponse();
        var reports = await this.reportRepository.GetByClientAndAppAsync(request.ClientId, request.AppId, cancellationToken);
        foreach (var report in reports)
        {
            var reportResponse = new ReportResponse
            {
                CreatedAt = report.CreatedAt
            };

            var @event = await this.mediator.Send(new GetEventByReportIdQuery(report.Id), cancellationToken);
            if (@event != null)
            {
                reportResponse.Event = new EventResponse
                {
                    Severity = @event.Severity,
                    IsHandled = @event.IsHandled
                };
            }

            // TODO: Add exceptions and trace lines

            result.Reports.Add(reportResponse);
        }

        return result;
    }
}
