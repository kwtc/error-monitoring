namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using Domain.Event;
using FluentValidation;

public class PersistEventValidator : AbstractValidator<Event>
{
    public PersistEventValidator()
    {
        this.RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("Client id cannot be empty");
        this.RuleFor(x => x.ApplicationId)
            .NotEmpty()
            .WithMessage("Application id cannot be empty");
        this.RuleFor(x => x.ExceptionType)
            .NotEmpty()
            .WithMessage("Exception type cannot be empty");
        this.RuleFor(x => x.Severity)
            .IsInEnum()
            .WithMessage("Severity must be a valid enum value");
        this.RuleFor(x => x.Exceptions)
            .NotEmpty()
            .WithMessage("Exceptions cannot be empty");
    }
}
