namespace Kwtc.ErrorMonitoring.Application.Reports.Queries;

using Domain.Event;
using MediatR;
using Persistence.Event;

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
