namespace Kwtc.ErrorMonitoring.Application.Report.Queries;

using Kwtc.ErrorMonitoring.Domain.Report;
using Kwtc.ErrorMonitoring.Persistence.Report;
using MediatR;

public record GetAllReportsQuery(Guid ClientId, Guid? AppId) : IRequest<IEnumerable<Report>>;

internal sealed class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, IEnumerable<Report>>
{
    private readonly IReportRepository reportRepository;

    public GetAllReportsQueryHandler(IReportRepository reportRepository)
    {
        this.reportRepository = reportRepository;
    }

    public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
    {
        return await this.reportRepository.GetByClientAndAppAsync(request.ClientId, request.AppId, cancellationToken);
    }
}
