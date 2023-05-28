namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Event;
using Models.Payload;

public class TraceMapper : IMapper<TracePayload, Trace>
{
    public void Map(TracePayload source, Trace target)
    {
        target.File = source.File;
        target.LineNumber = source.LineNumber;
        target.Method = source.Method;
    }
}
