namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report;

public class ExceptionMapper : IMapper<ExceptionPayload, Exception>
{
    private readonly IMapper<TracePayload, Trace> mapper;

    public ExceptionMapper(IMapper<TracePayload, Trace> mapper)
    {
        this.mapper = mapper;
    }

    public void Map(ExceptionPayload source, Exception target)
    {
        target.Type = source.Type;
        target.Message = source.Message;
    }
}
