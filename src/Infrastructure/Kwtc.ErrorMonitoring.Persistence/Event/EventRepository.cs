namespace Kwtc.ErrorMonitoring.Persistence.Event;

using Application.Abstractions.Database;
using Dapper;
using Domain.Report;

public class EventRepository : IEventRepository
{
    private readonly IConnectionFactory connectionFactory;

    public EventRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public async Task<Event> AddAsync(Event @event, CancellationToken cancellationToken = default)
    {
        var id = Guid.NewGuid();

        const string sql = @"INSERT INTO Event (Id, ReportId, AppIdentifier, ExceptionType, ExceptionMessage, Severity, IsHandled) 
                                VALUES (@Id, @ReportId, @AppIdentifier, @ExceptionType, @ExceptionMessage, @Severity, @IsHandled);";
        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        await connection.ExecuteAsync(new CommandDefinition(sql, new
        {
            Id = id,
            @event.ReportId,
            @event.AppIdentifier,
            @event.ExceptionType,
            @event.ExceptionMessage,
            @event.Severity,
            @event.IsHandled
        }, cancellationToken: cancellationToken));

        @event.Id = id;

        return @event;
    }

    public async Task<Event?> GetByReportIdAsync(Guid reportId, CancellationToken cancellationToken = default)
    {
        const string sql = @"SELECT *
                            FROM Report
                            WHERE ReportId = @ReportId";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<Event>(new CommandDefinition(sql, new
        {
            ReportId = reportId
        }, cancellationToken: cancellationToken));
    }

    public async Task<IEnumerable<Event>> GetByReportIdsAsync(IEnumerable<Guid> reportIds, CancellationToken cancellationToken = default)
    {
        const string sql = @"SELECT *
                            FROM Report
                            WHERE ReportId IN @ReportIds";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryAsync<Event>(new CommandDefinition(sql, new
        {
            ReportIds = reportIds
        }, cancellationToken: cancellationToken));
    }
}
