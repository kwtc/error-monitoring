namespace Kwtc.ErrorMonitoring.Persistence.Exception;

using Domain.Report;

public interface IExceptionRepository
{
    Task<IEnumerable<Exception>> AddBulkAsync(IEnumerable<Exception> exceptions, CancellationToken cancellationToken = default);
}
