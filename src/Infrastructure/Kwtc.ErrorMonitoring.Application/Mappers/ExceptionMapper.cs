namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report.Payload;

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
