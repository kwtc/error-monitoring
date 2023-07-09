using FluentValidation;
using Exception = Kwtc.ErrorMonitoring.Domain.Event.Exception;

namespace Kwtc.ErrorMonitoring.Application.Validation.Event;

public class PersistExceptionValidator : AbstractValidator<Exception>
{
    public PersistExceptionValidator()
    {
        this.RuleFor(x => x.EventId)
            .NotEmpty();

        this.RuleFor(x => x.Message)
            .NotEmpty();

        this.RuleFor(x => x.Type)
            .NotEmpty()
            .MaximumLength(512);
    }
}
