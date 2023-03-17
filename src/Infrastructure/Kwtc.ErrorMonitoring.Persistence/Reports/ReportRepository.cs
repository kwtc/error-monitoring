namespace Kwtc.ErrorMonitoring.Persistence.Reports;

using Abstractions.Reports;
using Domain.Models;

public class ReportRepository : IReportRepository
{
    public Task<Report> AddAsync(Report report, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Report>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
