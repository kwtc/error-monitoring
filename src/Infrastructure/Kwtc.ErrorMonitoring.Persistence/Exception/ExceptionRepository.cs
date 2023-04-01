namespace Kwtc.ErrorMonitoring.Persistence.Exception;

using Application.Abstractions.Database;
using Dapper;
using Domain.Report;
using Microsoft.Toolkit.Diagnostics;

public class ExceptionRepository : IExceptionRepository
{
    private readonly IConnectionFactory connectionFactory;

    public ExceptionRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public async Task<Exception> AddAsync(Exception exception, CancellationToken cancellationToken = default)
    {
        var id = Guid.NewGuid();

        const string sql = @"INSERT INTO Exception (Id, Type, EventId, Message)
                    VALUES (@Id, @Type, @EventId, @Message)";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        await connection.ExecuteAsync(new CommandDefinition(sql, new
        {
            Id = id,
            exception.Type,
            exception.EventId,
            exception.Message
        }, cancellationToken: cancellationToken));

        exception.Id = id;
        return exception;
    }
}
