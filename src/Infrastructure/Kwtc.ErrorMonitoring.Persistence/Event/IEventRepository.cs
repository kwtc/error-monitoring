namespace Kwtc.ErrorMonitoring.Persistence.Event;

public interface IEventRepository
{
    Task<Domain.Event.Event> AddAsync(Domain.Event.Event @event, CancellationToken cancellationToken = default);

    Task<Domain.Event.Event?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Domain.Event.Event>> GetByClientIdAndApplicationIdAsync(Guid clientId, Guid applicationId, CancellationToken cancellationToken = default);
}
