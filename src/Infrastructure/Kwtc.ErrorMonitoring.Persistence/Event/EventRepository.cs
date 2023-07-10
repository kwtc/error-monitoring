using Dapper;
using Kwtc.Persistence.Factories;

namespace Kwtc.ErrorMonitoring.Persistence.Event;

public class EventRepository : IEventRepository
{
    private readonly IConnectionFactory connectionFactory;

    public EventRepository(IConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }

    public async Task<Domain.Event.Event> AddAsync(Domain.Event.Event @event, CancellationToken cancellationToken = default)
    {
        var id = Guid.NewGuid();

        const string sql = @"INSERT INTO Event (Id, ClientId, ApplicationId, ExceptionType, Severity, IsHandled, CreatedAt) 
                                VALUES (@Id, @ClientId, @ApplicationId, @ExceptionType, @Severity, @IsHandled, @CreatedAt);";
        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        await connection.ExecuteAsync(new CommandDefinition(sql, new
        {
            Id = id,
            @event.ClientId,
            ApplicationID = @event.ApplicationId,
            @event.ExceptionType,
            @event.Severity,
            @event.IsHandled,
            CreatedAt = DateTime.UtcNow
        }, cancellationToken: cancellationToken));

        @event.Id = id;

        return @event;
    }

    public async Task<Domain.Event.Event?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = @"SELECT *
                            FROM Event
                            WHERE Id = @Id";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<Domain.Event.Event>(new CommandDefinition(sql, new
        {
            Id = id.ToString()
        }, cancellationToken: cancellationToken));
    }

    public async Task<IEnumerable<Domain.Event.Event>> GetByClientIdAndApplicationIdAsync(Guid clientId, Guid applicationId, CancellationToken cancellationToken = default)
    {
        const string sql = @"SELECT *
                            FROM Event
                            WHERE ClientId @ClientId
                            AND ApplicationId = @ApplicationId";

        using var connection = await this.connectionFactory.GetAsync(cancellationToken);
        return await connection.QueryAsync<Domain.Event.Event>(new CommandDefinition(sql, new
        {
            ClientId = clientId.ToString(),
            ApplicationId = applicationId.ToString()
        }, cancellationToken: cancellationToken));
    }
}
