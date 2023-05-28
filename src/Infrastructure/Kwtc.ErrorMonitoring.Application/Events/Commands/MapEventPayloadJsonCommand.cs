namespace Kwtc.ErrorMonitoring.Application.Events.Commands;

using System.Text.Json;
using Abstractions.Mapping;
using Domain.Event;
using MediatR;
using Models.Payload;

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
