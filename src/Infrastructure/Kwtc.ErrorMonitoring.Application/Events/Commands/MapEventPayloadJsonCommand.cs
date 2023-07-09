using System.Text.Json;
using Kwtc.ErrorMonitoring.Application.Abstractions.Mapping;
using Kwtc.ErrorMonitoring.Application.Models.Payload;
using Kwtc.ErrorMonitoring.Domain.Event;
using MediatR;

namespace Kwtc.ErrorMonitoring.Application.Events.Commands;

public record MapEventPayloadJsonCommand(string JsonContent) : IRequest<Event>;

internal sealed class MapEventPayloadJsonCommandHandler : IRequestHandler<MapEventPayloadJsonCommand, Event>
{
    private readonly IMapper<EventPayload, Event> eventMapper;

    public MapEventPayloadJsonCommandHandler(IMapper<EventPayload, Event> eventMapper)
    {
        this.eventMapper = eventMapper;
    }

    public Task<Event> Handle(MapEventPayloadJsonCommand request, CancellationToken cancellationToken)
    {
        // TODO: determine how to handle this exception properly
        var payload = JsonSerializer.Deserialize<EventPayload>(request.JsonContent)
                      ?? throw new InvalidOperationException("Unable to deserialize event payload.");

        var @event = this.eventMapper.MapNew(payload);

        return Task.FromResult(@event);
    }
}
