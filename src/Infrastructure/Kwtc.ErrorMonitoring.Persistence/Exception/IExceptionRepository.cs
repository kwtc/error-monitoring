namespace Kwtc.ErrorMonitoring.Persistence.Exception;

using Domain.Event;

public interface IExceptionRepository
{
    Task<Exception> AddAsync(Exception exception, CancellationToken cancellationToken = default);
}
