namespace Kwtc.ErrorMonitoring.Persistence.Event;

using Domain.Report;

public interface IEventRepository
{
    Task<Event> AddAsync(Event @event, CancellationToken cancellationToken = default);
}
