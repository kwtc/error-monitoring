namespace Kwtc.ErrorMonitoring.Persistence.Abstractions.Reports;

using Domain.Models;

public interface IReportRepository
{
    Task<Report> AddAsync(Report report, CancellationToken cancellationToken = default); 
}
