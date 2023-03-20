namespace Kwtc.ErrorMonitoring.Persistence.Reports;

using Abstractions.Reports;
using Domain.ErrorReport;

public class ReportRepository : IReportRepository
{
    public Task<ErrorReport> AddAsync(ErrorReport errorReport, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ErrorReport>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
