namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using FluentValidation;
using Reports.Commands;

public class MapEventPayloadJsonCommandValidator : AbstractValidator<MapEventPayloadJsonCommand>
{
    public MapEventPayloadJsonCommandValidator()
    {
        this.RuleFor(x => x.JsonContent)
            .NotEmpty()
            .WithMessage("Json content cannot be empty");
    }
}
