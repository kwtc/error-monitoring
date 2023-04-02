namespace Kwtc.ErrorMonitoring.Persistence.Trace;

using Domain.Report;

public interface ITraceRepository
{
    Task AddBulkAsync(IEnumerable<Trace> traces, CancellationToken cancellationToken = default);
}
