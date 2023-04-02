namespace Kwtc.ErrorMonitoring.Persistence.Exception;

using Application.Abstractions.Database;
using Dapper;
using Domain.Report;

public class ExceptionRepository : IExceptionRepository
{
    private readonly IConnectionFactory connectionFactory;

    public ExceptionRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public async Task<Exception> AddAsync(Exception exception, CancellationToken cancellationToken = default)
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
