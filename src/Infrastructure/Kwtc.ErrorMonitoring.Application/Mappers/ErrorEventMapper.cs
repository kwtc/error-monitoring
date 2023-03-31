namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.ErrorReport;
using Models.Payload.ErrorReport;

public class ErrorEventMapper : IMapper<ErrorEventPayload, ErrorEvent>
{
    public void Map(ErrorEventPayload source, ErrorEvent target)
    {
        target.Severity = EnumUtils.GetValueFromDescription<Severity>(source.Severity);
        target.IsHandled = source.IsHandled;
    }
}
