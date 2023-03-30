namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Queries;

using Domain.ErrorReport;
using Persistence.Reports;
using MediatR;

public record GetAllErrorReportsQuery : IRequest<IEnumerable<ErrorReport>>;

internal sealed class GetAllErrorReportsQueryHandler : IRequestHandler<GetAllErrorReportsQuery, IEnumerable<ErrorReport>>
{
    private readonly IErrorReportRepository errorReportRepository;

    public GetAllErrorReportsQueryHandler(IErrorReportRepository errorReportRepository)
    {
        this.errorReportRepository = errorReportRepository;
    }

    public async Task<IEnumerable<ErrorReport>> Handle(GetAllErrorReportsQuery request, CancellationToken cancellationToken)
    {
        return await this.errorReportRepository.GetAllAsync(cancellationToken);
    }
}
