using Kwtc.ErrorMonitoring.Application.Abstractions.Mapping;
using Kwtc.ErrorMonitoring.Application.Models.Payload;
using Kwtc.ErrorMonitoring.Domain.Event;
using Exception = Kwtc.ErrorMonitoring.Domain.Event.Exception;

namespace Kwtc.ErrorMonitoring.Application.Mappers;

public class ExceptionMapper : IMapper<ExceptionPayload, Exception>
{
    private readonly IMapper<TracePayload, Trace> traceMapper;

    public ExceptionMapper(IMapper<TracePayload, Trace> traceMapper)
    {
        this.traceMapper = traceMapper;
    }
    
    public void Map(ExceptionPayload source, Exception target)
    {
        target.Type = source.Type;
        target.Message = source.Message;
        target.TraceLines = this.traceMapper.MapCollection(source.Trace).ToList();
    }
}
