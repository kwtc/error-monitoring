namespace Kwtc.ErrorMonitoring.Application.Reports.Queries;

using Domain.Report;
using Kwtc.ErrorMonitoring.Persistence.Reports;
using MediatR;

public record GetAllReportsQuery : IRequest<IEnumerable<Report>>;

internal sealed class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, IEnumerable<Report>>
{
    private readonly IErrorReportRepository errorReportRepository;

    public GetAllReportsQueryHandler(IErrorReportRepository errorReportRepository)
    {
        this.errorReportRepository = errorReportRepository;
    }

    public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
    {
        return await this.errorReportRepository.GetAllAsync(cancellationToken);
    }
}
