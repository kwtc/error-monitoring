namespace Kwtc.ErrorMonitoring.Persistence.Report;

using Dapper;
using Application.Abstractions.Database;
using Kwtc.ErrorMonitoring.Domain.Report;

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

        const string sql = @"INSERT INTO Report (Id, ClientId) 
                                VALUES (@Id, @ClientId); 
                            SELECT CreatedAt FROM Report WHERE Id = @Id;";
        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        var createdAt = await connection.ExecuteScalarAsync<DateTime>(new CommandDefinition(sql, new
        {
            Id = id,
            report.ClientId
        }, cancellationToken: cancellationToken));

        report.Id = id;
        report.CreatedAt = createdAt;

        return report;
    }

    public async Task<IEnumerable<Report>> GetByClientAndAppAsync(Guid clientId, Guid appId, CancellationToken cancellationToken = default)
    {
        const string sql = @"SELECT *
                            FROM Report
                            WHERE ClientId = @ClientId
                            AND AppId = @AppId;";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryAsync<Report>(new CommandDefinition(sql, new
        {
            ClientId = clientId,
            AppId = appId
        }, cancellationToken: cancellationToken));
    }
}
