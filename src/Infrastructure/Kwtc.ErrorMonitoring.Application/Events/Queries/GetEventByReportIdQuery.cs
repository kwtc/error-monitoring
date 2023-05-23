namespace Kwtc.ErrorMonitoring.Application.Events.Queries;

using Domain.Report;
using Persistence.Event;
using MediatR;

public record GetEventByReportIdQuery(Guid ReportId) : IRequest<Event?>;

internal sealed class GetEventByReportIdQueryHandler : IRequestHandler<GetEventByReportIdQuery, Event?>
{
    private readonly IEventRepository eventRepository;

    public GetEventByReportIdQueryHandler(IEventRepository eventRepository)
    {
        this.eventRepository = eventRepository;
    }

    public async Task<Event?> Handle(GetEventByReportIdQuery request, CancellationToken cancellationToken)
    {
        return await this.eventRepository.GetByReportIdAsync(request.ReportId, cancellationToken);
    }
}
