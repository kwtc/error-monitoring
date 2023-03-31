namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Queries;

using Domain.Report;
using Persistence.Reports;
using MediatR;

public record GetAllErrorReportsQuery : IRequest<IEnumerable<Report>>;

internal sealed class GetAllErrorReportsQueryHandler : IRequestHandler<GetAllErrorReportsQuery, IEnumerable<Report>>
{
    private readonly IErrorReportRepository errorReportRepository;

    public GetAllErrorReportsQueryHandler(IErrorReportRepository errorReportRepository)
    {
        this.errorReportRepository = errorReportRepository;
    }

    public async Task<IEnumerable<Report>> Handle(GetAllErrorReportsQuery request, CancellationToken cancellationToken)
    {
        return await this.errorReportRepository.GetAllAsync(cancellationToken);
    }
}
