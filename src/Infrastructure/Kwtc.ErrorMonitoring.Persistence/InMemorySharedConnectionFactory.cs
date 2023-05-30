namespace Kwtc.ErrorMonitoring.Persistence;

using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

public class InMemorySharedConnectionFactory : IInMemoryConnectionFactory, IDisposable
{
    private readonly SqliteConnection connection;
    private readonly string connectionString;

    public InMemorySharedConnectionFactory()
    {
        var dataSource = Guid.NewGuid().ToString().Replace("-", string.Empty);
        this.connectionString = $"Data Source={dataSource};Mode=Memory;Cache=Shared";
        SQLitePCL.Batteries.Init();
        this.connection = new SqliteConnection(this.connectionString);

        this.connection.Open();
    }

    public void Dispose()
    {
        this.connection.Close();
        this.connection.Dispose();
    }

    public async Task<IDbConnection> GetAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SqliteConnection(this.connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }

    public void CreateTableIfNotExists<T>()
    {
        if (this.connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        var sql = this.CreateTableSql<T>();
        connection.Execute(sql);
    }
}
