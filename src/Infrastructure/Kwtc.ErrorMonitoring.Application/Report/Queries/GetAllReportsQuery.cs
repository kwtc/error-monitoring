namespace Kwtc.ErrorMonitoring.Application.Report.Queries;

using Kwtc.ErrorMonitoring.Domain.Report;
using Kwtc.ErrorMonitoring.Persistence.Report;
using MediatR;
using Persistence.Event;

public record GetAllReportsQuery(Guid ClientId, Guid? AppId = null) : IRequest<IEnumerable<Report>>;

internal sealed class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, IEnumerable<Report>>
{
    private readonly IReportRepository reportRepository;
    private readonly IEventRepository eventRepository;

    public GetAllReportsQueryHandler(IReportRepository reportRepository, IEventRepository eventRepository)
    {
        this.reportRepository = reportRepository;
        this.eventRepository = eventRepository;
    }

    public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
    {
        var reports = (await this.reportRepository.GetByClientAndAppAsync(request.ClientId, request.AppId, cancellationToken)).ToList();
        foreach (var report in reports)
        {
            var @event = await this.eventRepository.GetByReportIdAsync(report.Id, cancellationToken)
                         ?? throw new InvalidOperationException("Report event not found");
        }

        return reports;
    }
}
