namespace Kwtc.ErrorMonitoring.Persistence.Exception;

using Domain.Report;

public interface IExceptionRepository
{
    Task<Exception> AddAsync(Exception exception, CancellationToken cancellationToken = default);
}
