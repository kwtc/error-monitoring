namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report.Payload;

public class ReportMapper : IMapper<ReportPayload, Report>
{
    private readonly IMapper<EventPayload, Event> eventMapper;

    public ReportMapper(IMapper<EventPayload, Event> eventMapper)
    {
        this.eventMapper = eventMapper;
    }
    
    public void Map(ReportPayload source, Report target)
    {
        target.ApplicationId = Guid.Parse(source.ApplicationId);
        target.Event = this.eventMapper.MapNew(source.EventPayload);
    }
}
