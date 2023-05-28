namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using Domain.Event;
using FluentValidation;

public class PersistExceptionValidator : AbstractValidator<Exception>
{
    public PersistExceptionValidator()
    {
        this.RuleFor(x => x.EventId)
            .NotEmpty()
            .WithMessage("Event id cannot be empty");

        this.RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Message cannot be empty");

        this.RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type cannot be empty");
    }
}
