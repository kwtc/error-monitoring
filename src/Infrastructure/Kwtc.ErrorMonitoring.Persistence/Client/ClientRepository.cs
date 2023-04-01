namespace Kwtc.ErrorMonitoring.Persistence.Client;

using Application.Abstractions.Database;
using Dapper;
using Domain.Client;

public class ClientRepository : IClientRepository
{
    private readonly IConnectionFactory connectionFactory;

    public ClientRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public Task<Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Client?> GetClientByApiKeyAsync(string apiKey, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Client?> GetAClientAsync(CancellationToken cancellationToken = default)
    {
        const string sql = @"
            SELECT Id, ApiKey, CreatedAt
            FROM Client
            LIMIT 1";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<Client>(new CommandDefinition(sql, cancellationToken: cancellationToken));
    }
}
