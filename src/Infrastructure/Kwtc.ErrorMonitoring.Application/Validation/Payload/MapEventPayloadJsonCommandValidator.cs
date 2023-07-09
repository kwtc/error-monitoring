using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Events.Commands;

namespace Kwtc.ErrorMonitoring.Application.Validation.Payload;

public class MapEventPayloadJsonCommandValidator : AbstractValidator<MapEventPayloadJsonCommand>
{
    public MapEventPayloadJsonCommandValidator()
    {
        this.RuleFor(x => x.JsonContent)
            .NotEmpty();
    }
}
