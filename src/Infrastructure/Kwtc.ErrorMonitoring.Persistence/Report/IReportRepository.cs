namespace Kwtc.ErrorMonitoring.Persistence.Report;

using Kwtc.ErrorMonitoring.Domain.Report;

public interface IReportRepository
{
    Task<Report> AddAsync(Report report, CancellationToken cancellationToken = default);

    Task<IEnumerable<Report>> GetByClientAndAppAsync(Guid clientId, Guid appId, CancellationToken cancellationToken = default);
}
