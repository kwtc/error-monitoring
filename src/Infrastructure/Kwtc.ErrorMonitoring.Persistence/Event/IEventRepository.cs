namespace Kwtc.ErrorMonitoring.Persistence.Event;

using Domain.Report;

public interface IEventRepository
{
    Task<Event> AddAsync(Event @event, CancellationToken cancellationToken = default);

    Task<Event?> GetByReportIdAsync(Guid reportId, CancellationToken cancellationToken = default);

    Task<IEnumerable<Event>> GetByReportIdsAsync(IEnumerable<Guid> reportIds, CancellationToken cancellationToken = default);
}
