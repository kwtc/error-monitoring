namespace Kwtc.ErrorMonitoring.Persistence.Exception;

public interface IExceptionRepository
{
    Task<Domain.Event.Exception> AddAsync(Domain.Event.Exception exception, CancellationToken cancellationToken = default);
}
