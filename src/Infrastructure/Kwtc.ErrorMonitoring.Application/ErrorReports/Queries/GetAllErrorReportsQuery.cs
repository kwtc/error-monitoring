namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Queries;

using Domain.Models.ErrorReport;
using Kwtc.ErrorMonitoring.Persistence.Abstractions.Reports;
using MediatR;

public record GetAllErrorReportsQuery : IRequest<IEnumerable<ErrorReport>>;

internal sealed class GetAllErrorReportsQueryHandler : IRequestHandler<GetAllErrorReportsQuery, IEnumerable<ErrorReport>>
{
    private readonly IReportRepository reportRepository;

    public GetAllErrorReportsQueryHandler(IReportRepository reportRepository)
    {
        this.reportRepository = reportRepository;
    }

    public async Task<IEnumerable<ErrorReport>> Handle(GetAllErrorReportsQuery request, CancellationToken cancellationToken)
    {
        return await this.reportRepository.GetAllAsync(cancellationToken);
    }
}
