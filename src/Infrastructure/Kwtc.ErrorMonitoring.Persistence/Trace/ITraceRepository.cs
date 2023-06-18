namespace Kwtc.ErrorMonitoring.Persistence.Trace;

public interface ITraceRepository
{
    Task AddBulkAsync(IEnumerable<Domain.Event.Trace> traces, CancellationToken cancellationToken = default);
}
