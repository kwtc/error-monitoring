namespace Kwtc.ErrorMonitoring.Application.Abstractions.Database;

using System.Data;

public interface IConnectionFactory
{
    Task<IDbConnection> GetAsync(CancellationToken cancellationToken = default);
}
