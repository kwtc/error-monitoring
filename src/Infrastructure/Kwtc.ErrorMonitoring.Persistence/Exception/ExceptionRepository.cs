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

    public async Task<IEnumerable<Exception>> AddBulkAsync(IEnumerable<Exception> exceptions, CancellationToken cancellationToken = default)
    {
        Guard.IsFalse(exceptions.Any(), nameof(exceptions));
        var result = new List<Exception>();

        var sql = "INSERT INTO Exception (Id, Type, EventId, Message) VALUES ";
        foreach (var exception in exceptions)
        {
            exception.Id = Guid.NewGuid(); 
            sql += $"('{exception.Id}', '{exception.Type}', '{exception.EventId}', '{exception.Message}'),";
            
            result.Add(exception);
        }
        
        sql = sql.TrimEnd(',') + ";";
        
        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        await connection.ExecuteAsync(new CommandDefinition(sql, cancellationToken: cancellationToken));
        
        return result;
    }
}
