namespace Kwtc.ErrorMonitoring.Application.Events.Queries;

using Domain.Event;
using Persistence.Event;
using MediatR;

public record GetEventByIdQuery(Guid ReportId) : IRequest<Event?>;

internal sealed class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event?>
{
    private readonly IEventRepository eventRepository;

    public GetEventByIdQueryHandler(IEventRepository eventRepository)
    {
        this.eventRepository = eventRepository;
    }

    public async Task<Event?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        return await this.eventRepository.GetByIdAsync(request.ReportId, cancellationToken);
    }
}
