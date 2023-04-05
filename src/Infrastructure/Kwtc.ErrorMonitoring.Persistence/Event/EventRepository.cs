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

        const string sql = @"INSERT INTO Event (Id, ReportId, Severity, IsHandled) 
                                VALUES (@Id, @ReportId, @Severity, @IsHandled);";
        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        await connection.ExecuteAsync(new CommandDefinition(sql, new
        {
            Id = id,
            @event.ReportId,
            @event.Severity,
            @event.IsHandled
        }, cancellationToken: cancellationToken));

        @event.Id = id;

        return @event;
    }

    public Task<Event?> GetByReportIdAsync(Guid reportId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
