namespace Kwtc.ErrorMonitoring.Application.Validation.Event;

using FluentValidation;
using Kwtc.ErrorMonitoring.Domain.Event;

public class PersistEventValidator : AbstractValidator<Event>
{
    public PersistEventValidator()
    {
        this.RuleFor(x => x.ClientId)
            .NotEmpty();
        this.RuleFor(x => x.ApplicationId)
            .NotEmpty();
        this.RuleFor(x => x.ExceptionType)
            .NotEmpty()
            .MaximumLength(512);
        this.RuleFor(x => x.Severity)
            .IsInEnum();
        this.RuleFor(x => x.Exceptions)
            .NotEmpty();
    }
}
