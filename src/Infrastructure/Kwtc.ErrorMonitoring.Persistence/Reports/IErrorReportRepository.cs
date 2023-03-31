namespace Kwtc.ErrorMonitoring.Persistence.Reports;

using Domain.Report;

public interface IErrorReportRepository
{
    Task<Report> AddAsync(Report report, CancellationToken cancellationToken = default); 
    
    Task<IEnumerable<Report>> GetAllAsync(CancellationToken cancellationToken = default);
}
