using Kwtc.ErrorMonitoring.Application.Abstractions.Mapping;
using Kwtc.ErrorMonitoring.Application.Models.Payload;
using Kwtc.ErrorMonitoring.Domain.Event;
using Exception = Kwtc.ErrorMonitoring.Domain.Event.Exception;

namespace Kwtc.ErrorMonitoring.Application.Mappers;

public class EventMapper : IMapper<EventPayload, Event>
{
    private readonly IMapper<ExceptionPayload, Exception> exceptionMapper;

    public EventMapper(IMapper<ExceptionPayload, Exception> exceptionMapper)
    {
        this.exceptionMapper = exceptionMapper;
    }

    public void Map(EventPayload source, Event target)
    {
        target.ApplicationId = Guid.Parse(source.ApplicationId);
        target.ExceptionType = source.ExceptionType;
        target.Severity = EnumUtils.GetValueFromDescription<Severity>(source.Severity);
        target.IsHandled = source.IsHandled;
        target.Exceptions = this.exceptionMapper.MapCollection(source.Exceptions).ToList();
        target.Metadata = source.Metadata;
    }
}
