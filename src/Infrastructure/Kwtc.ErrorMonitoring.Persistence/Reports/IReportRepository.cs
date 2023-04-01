namespace Kwtc.ErrorMonitoring.Persistence.Reports;

using Domain.Report;

public interface IReportRepository
{
    Task<Report> AddAsync(Report report, CancellationToken cancellationToken = default);

    Task<IEnumerable<Report>> GetAllAsync(Guid clientId, Guid? appId = null, CancellationToken cancellationToken = default);
}
