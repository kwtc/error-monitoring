namespace Kwtc.ErrorMonitoring.Application.Validators.Report;

using Domain.Report;
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
        
        this.RuleFor(x => x.Trace)
            .NotEmpty()
            .WithMessage("Trace cannot be empty");
    }
}
