namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report.Payload;

public class EventMapper : IMapper<EventPayload, Event>
{
    private readonly IMapper<ExceptionPayload, Exception> exceptionMapper;

    public EventMapper(IMapper<ExceptionPayload, Exception> exceptionMapper)
    {
        this.exceptionMapper = exceptionMapper;
    }

    public void Map(EventPayload source, Event target)
    {
        target.AppIdentifier = source.AppIdentifier;
        target.ExceptionType = source.ExceptionType;
        target.ExceptionMessage = source.ExceptionMessage;
        target.Severity = EnumUtils.GetValueFromDescription<Severity>(source.Severity);
        target.IsHandled = source.IsHandled;
        target.Exceptions = this.exceptionMapper.MapCollection(source.Exceptions).ToList();
    }
}
