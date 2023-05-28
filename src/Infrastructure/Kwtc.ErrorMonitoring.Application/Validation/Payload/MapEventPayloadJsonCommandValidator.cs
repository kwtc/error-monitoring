namespace Kwtc.ErrorMonitoring.Application.Validation.Payload;

using Events.Commands;
using FluentValidation;

public class MapEventPayloadJsonCommandValidator : AbstractValidator<MapEventPayloadJsonCommand>
{
    public MapEventPayloadJsonCommandValidator()
    {
        this.RuleFor(x => x.JsonContent)
            .NotEmpty();
    }
}
