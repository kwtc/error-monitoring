namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report.Payload;

public class EventMapper : IMapper<EventPayload, Event>
{
    public void Map(EventPayload source, Event target)
    {
        target.AppIdentifier = source.AppIdentifier;
        target.ExceptionType = source.ExceptionType;
        target.ExceptionMessage = source.ExceptionMessage;
        target.Severity = EnumUtils.GetValueFromDescription<Severity>(source.Severity);
        target.IsHandled = source.IsHandled;
    }
}
