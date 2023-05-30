namespace Kwtc.ErrorMonitoring.Persistence;

using Application.Abstractions.Database;

public interface IInMemoryConnectionFactory : IConnectionFactory
{
    void CreateTableIfNotExists<T>();
}
