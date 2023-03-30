namespace Kwtc.ErrorMonitoring.Persistence.Reports;

using Domain.ErrorReport;

public interface IErrorReportRepository
{
    Task<ErrorReport> AddAsync(ErrorReport errorReport, CancellationToken cancellationToken = default); 
    
    Task<IEnumerable<ErrorReport>> GetAllAsync(CancellationToken cancellationToken = default);
}
