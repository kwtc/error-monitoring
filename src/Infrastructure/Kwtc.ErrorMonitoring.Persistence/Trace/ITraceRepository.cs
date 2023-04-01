namespace Kwtc.ErrorMonitoring.Persistence.Trace;

using Domain.Report;

public interface ITraceRepository
{
    Task<IEnumerable<Trace>> AddBulkAsync(IEnumerable<Trace> traces, CancellationToken cancellationToken = default);
}
