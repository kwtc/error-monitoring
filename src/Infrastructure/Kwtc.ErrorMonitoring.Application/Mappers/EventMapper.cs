namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report;

public class EventMapper : IMapper<EventPayload, Event>
{
    private readonly IMapper<ExceptionPayload, Exception> mapper;

    public EventMapper(IMapper<ExceptionPayload, Exception> mapper)
    {
        this.mapper = mapper;
    }

    public void Map(EventPayload source, Event target)
    {
        target.Severity = EnumUtils.GetValueFromDescription<Severity>(source.Severity);
        target.IsHandled = source.IsHandled;
        target.Exceptions = this.mapper.MapCollection(source.Exceptions).ToList();
    }
}
