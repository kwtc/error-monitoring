using Kwtc.ErrorMonitoring.Domain.Event;
using Kwtc.ErrorMonitoring.Persistence.Event;
using MediatR;

namespace Kwtc.ErrorMonitoring.Application.Events.Queries;

public record GetEventByIdQuery(Guid Id) : IRequest<Event?>;

internal sealed class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event?>
{
    private readonly IEventRepository eventRepository;

    public GetEventByIdQueryHandler(IEventRepository eventRepository)
    {
        this.eventRepository = eventRepository;
    }

    public async Task<Event?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        return await this.eventRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
