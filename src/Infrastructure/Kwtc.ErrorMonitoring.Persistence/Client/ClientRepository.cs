using Dapper;
using Kwtc.Persistence.Factories;

namespace Kwtc.ErrorMonitoring.Persistence.Client;

public class ClientRepository : IClientRepository
{
    private readonly IConnectionFactory connectionFactory;

    public ClientRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public Task<Domain.Client.Client?> GetClientByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Client.Client?> GetClientByApiKeyAsync(Guid apiKey, CancellationToken cancellationToken = default)
    {
        const string query = @"
            SELECT * 
            FROM Client 
            WHERE ApiKey = @ApiKey 
            LIMIT 1";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<Domain.Client.Client>(new CommandDefinition(query, new { ApiKey = apiKey }, cancellationToken: cancellationToken));
    }

    public async Task<Domain.Client.Client?> GetClientAsync(CancellationToken cancellationToken = default)
    {
        const string sql = @"
            SELECT Id, ApiKey, CreatedAt
            FROM Client
            LIMIT 1";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<Domain.Client.Client>(new CommandDefinition(sql, cancellationToken: cancellationToken));
    }
}
