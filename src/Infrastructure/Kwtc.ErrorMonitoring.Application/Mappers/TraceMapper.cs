using Kwtc.ErrorMonitoring.Application.Abstractions.Mapping;
using Kwtc.ErrorMonitoring.Application.Models.Payload;
using Kwtc.ErrorMonitoring.Domain.Event;

namespace Kwtc.ErrorMonitoring.Application.Mappers;

public class TraceMapper : IMapper<TracePayload, Trace>
{
    public void Map(TracePayload source, Trace target)
    {
        target.File = source.File;
        target.LineNumber = source.LineNumber;
        target.Method = source.Method;
    }
}
