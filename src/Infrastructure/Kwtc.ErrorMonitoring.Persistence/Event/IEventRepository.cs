namespace Kwtc.ErrorMonitoring.Persistence.Event;

using Domain.Event;

public interface IEventRepository
{
    Task<Event> AddAsync(Event @event, CancellationToken cancellationToken = default);

    Task<Event?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Event>> GetByClientIdAndApplicationIdAsync(Guid clientId, Guid applicationId, CancellationToken cancellationToken = default);
}
