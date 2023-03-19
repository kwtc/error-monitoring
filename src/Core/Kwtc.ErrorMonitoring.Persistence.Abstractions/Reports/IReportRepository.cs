namespace Kwtc.ErrorMonitoring.Persistence.Abstractions.Reports;

using Domain.Models.ErrorReport;

public interface IReportRepository
{
    Task<ErrorReport> AddAsync(ErrorReport errorReport, CancellationToken cancellationToken = default); 
    
    Task<IEnumerable<ErrorReport>> GetAllAsync(CancellationToken cancellationToken = default);
}
