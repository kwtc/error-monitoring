namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.ErrorReport;
using Mapping;
using Models.Payload.ErrorReport;

public class ErrorReportMapper : IMapper<ErrorReportPayload, ErrorReport>
{
    private readonly IMapper<ErrorEventPayload, ErrorEvent> errorEventMapper;

    public ErrorReportMapper(IMapper<ErrorEventPayload, ErrorEvent> errorEventMapper)
    {
        this.errorEventMapper = errorEventMapper;
    }

    public void Map(ErrorReportPayload source, ErrorReport target)
    {
        target.Event = this.errorEventMapper.MapNew(source.Event);
    }
}
