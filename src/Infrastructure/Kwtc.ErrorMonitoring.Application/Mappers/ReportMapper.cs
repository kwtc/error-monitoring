namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report;

public class ReportMapper : IMapper<ReportPayload, Report>
{
    private readonly IMapper<EventPayload, Event> errorEventMapper;

    public ReportMapper(IMapper<EventPayload, Event> errorEventMapper)
    {
        this.errorEventMapper = errorEventMapper;
    }

    public void Map(ReportPayload source, Report target)
    {
        target.AppId = source.AppId;
        target.Event = this.errorEventMapper.MapNew(source.Event);
    }
}
