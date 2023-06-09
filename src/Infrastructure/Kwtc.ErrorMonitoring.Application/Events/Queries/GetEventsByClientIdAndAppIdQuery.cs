using Kwtc.ErrorMonitoring.Domain.Event;
using Kwtc.ErrorMonitoring.Persistence.Event;
using MediatR;

namespace Kwtc.ErrorMonitoring.Application.Events.Queries;

public record GetEventsByClientIdAndAppIdQuery(Guid ClientId, Guid AppId) : IRequest<IEnumerable<Event>>;

internal sealed class GetEventsByClientAndAppIdsQueryHandler : IRequestHandler<GetEventsByClientIdAndAppIdQuery, IEnumerable<Event>>
{
    private readonly IEventRepository eventRepository;

    public GetEventsByClientAndAppIdsQueryHandler(IEventRepository eventRepository)
    {
        this.eventRepository = eventRepository;
    }

    public async Task<IEnumerable<Event>> Handle(GetEventsByClientIdAndAppIdQuery request, CancellationToken cancellationToken)
    {
        return await this.eventRepository.GetByClientIdAndApplicationIdAsync(request.ClientId, request.AppId, cancellationToken);
    }
}
