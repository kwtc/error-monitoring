using Dapper;
using Kwtc.Persistence.Factories;

namespace Kwtc.ErrorMonitoring.Persistence.Exception;

public class ExceptionRepository : IExceptionRepository
{
    private readonly IConnectionFactory connectionFactory;

    public ExceptionRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public async Task<Domain.Event.Exception> AddAsync(Domain.Event.Exception exception, CancellationToken cancellationToken = default)
    {
        const string sql = @"INSERT INTO Exception (Type, EventId, Message)
                            VALUES (@Type, @EventId, @Message);
                            SELECT LAST_INSERT_ID();"; 

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        var id = await connection.ExecuteScalarAsync<int>(new CommandDefinition(sql, new
        {
            exception.Type,
            exception.EventId,
            exception.Message
        }, cancellationToken: cancellationToken));

        exception.Id = id;
        return exception;
    }
}
