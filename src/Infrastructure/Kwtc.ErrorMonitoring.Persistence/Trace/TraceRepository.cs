namespace Kwtc.ErrorMonitoring.Persistence.Trace;

using Application.Abstractions.Database;
using Dapper;
using Domain.Report;
using Microsoft.Toolkit.Diagnostics;

public class TraceRepository : ITraceRepository
{
    private readonly IConnectionFactory connectionFactory;

    public TraceRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public async Task AddBulkAsync(IEnumerable<Trace> traces, CancellationToken cancellationToken = default)
    {
        Guard.IsTrue(traces.Any(), nameof(traces));

        var sql = "INSERT INTO Trace (ExceptionId, File, LineNumber, Method) VALUES ";
        foreach (var trace in traces)
        {
            sql += $"('{trace.ExceptionId}', '{trace.File}', '{trace.LineNumber}', '{trace.Method}'),";
        }

        sql = sql.TrimEnd(',') + ";";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        await connection.ExecuteAsync(new CommandDefinition(sql, cancellationToken: cancellationToken));
    }
}
