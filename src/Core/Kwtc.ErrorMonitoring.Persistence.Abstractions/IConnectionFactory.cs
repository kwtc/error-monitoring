namespace Kwtc.ErrorMonitoring.Persistence.Abstractions;

using System.Data;

public interface IConnectionFactory
{
    Task<IDbConnection> GetAsync(CancellationToken cancellationToken = default);
}
