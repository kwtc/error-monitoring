namespace Kwtc.ErrorMonitoring.Persistence.Trace;

using Domain.Event;

public interface ITraceRepository
{
    Task AddBulkAsync(IEnumerable<Trace> traces, CancellationToken cancellationToken = default);
}
