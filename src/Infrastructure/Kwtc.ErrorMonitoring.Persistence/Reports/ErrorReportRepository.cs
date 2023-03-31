namespace Kwtc.ErrorMonitoring.Persistence.Reports;

using Application.Abstractions.Database;
using Dapper;
using Domain.ErrorReport;

public class ErrorReportRepository : IErrorReportRepository
{
    private readonly IConnectionFactory connectionFactory;

    public ErrorReportRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }
    
    public async Task<ErrorReport> AddAsync(ErrorReport errorReport, CancellationToken cancellationToken = default)
    {
        // // TODO: Determine how to persist inner exceptions etc.
        //
        // errorReport.Id = Guid.NewGuid();
        //
        // const string sql = @"
        //     INSERT INTO ErrorReports (Id, AppId, Severity, Message, Source, StackTrace, InnerException)
        //     VALUES (@Id, @AppId, @Severity, @Message, @Source, @StackTrace, @InnerException)";
        //
        // using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        // await connection.ExecuteAsync(new CommandDefinition(sql, new
        // {
        //     errorReport.Id,
        //     errorReport.Severity,
        //     errorReport.OriginalException?.Message,
        //     errorReport.OriginalException?.Source,
        //     errorReport.OriginalException?.StackTrace,
        //     errorReport.OriginalException?.InnerException
        // }, cancellationToken: cancellationToken));

        return errorReport;
    }

    public async Task<IEnumerable<ErrorReport>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        // TODO: Probably never going to be used like this.. need to get all by client/user etc.
        
        const string sql = @"
            SELECT Id, AppId, Severity, Message, Source, StackTrace, InnerException
            FROM ErrorReports";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryAsync<ErrorReport>(new CommandDefinition(sql, cancellationToken: cancellationToken));
    }
}