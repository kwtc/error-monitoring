namespace Kwtc.ErrorMonitoring.Application.Event.Queries;

using Domain.Report;
using MediatR;
using Persistence.Event;

public record GetEventByReportIdQuery(Guid ReportId) : IRequest<Event?>;

internal sealed class GetEventByIdQueryHandler : IRequestHandler<GetEventByReportIdQuery, Event?>
{
    private readonly IEventRepository eventRepository;

    public GetEventByIdQueryHandler(IEventRepository eventRepository)
    {
        this.eventRepository = eventRepository;
    }

    public async Task<Event?> Handle(GetEventByReportIdQuery request, CancellationToken cancellationToken)
    {
        return await this.eventRepository.GetByReportIdAsync(request.ReportId, cancellationToken);
    }
}
