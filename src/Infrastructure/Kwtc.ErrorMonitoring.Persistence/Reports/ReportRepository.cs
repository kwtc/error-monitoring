namespace Kwtc.ErrorMonitoring.Persistence.Reports;

using Application.Abstractions.Database;
using Dapper;
using Domain.Report;

public class ReportRepository : IReportRepository
{
    private readonly IConnectionFactory connectionFactory;

    public ReportRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public async Task<Report> AddAsync(Report report, CancellationToken cancellationToken = default)
    {
        var id = Guid.NewGuid();

        const string sql = @"INSERT INTO Report (Id, AppId, ClientId) 
                                VALUES (@Id, @AppId, @ClientId); 
                            SELECT CreatedAt FROM Report WHERE Id = @Id;";
        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        var createdAt = await connection.ExecuteScalarAsync<DateTime>(new CommandDefinition(sql, new
        {
            Id = id,
            report.AppId,
            report.ClientId
        }, cancellationToken: cancellationToken));

        report.Id = id;
        report.CreatedAt = createdAt;

        return report;
    }

    public async Task<IEnumerable<Report>> GetAllAsync(Guid clientId, Guid? appId = null, CancellationToken cancellationToken = default)
    {
        // TODO: Probably never going to be used like this.. need to get all by client/user etc.

        const string sql = @"
            SELECT Id, AppId, Severity, Message, Source, StackTrace, InnerException
            FROM ErrorReports";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryAsync<Report>(new CommandDefinition(sql, cancellationToken: cancellationToken));
    }
}
