namespace Kwtc.ErrorMonitoring.Application.Reports.Queries;

using Domain.Models;
using MediatR;
using Persistence.Abstractions.Reports;

public record GetAllErrorReportsQuery : IRequest<IEnumerable<Report>>;

internal sealed class GetAllErrorReportsQueryHandler : IRequestHandler<GetAllErrorReportsQuery, IEnumerable<Report>>
{
    private readonly IReportRepository reportRepository;

    public GetAllErrorReportsQueryHandler(IReportRepository reportRepository)
    {
        this.reportRepository = reportRepository;
    }

    public async Task<IEnumerable<Report>> Handle(GetAllErrorReportsQuery request, CancellationToken cancellationToken)
    {
        return await this.reportRepository.GetAllAsync(cancellationToken);
    }
}
