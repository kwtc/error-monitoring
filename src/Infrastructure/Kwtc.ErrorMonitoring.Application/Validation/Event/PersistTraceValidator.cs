using FluentValidation;
using Kwtc.ErrorMonitoring.Domain.Event;

namespace Kwtc.ErrorMonitoring.Application.Validation.Event;

public class PersistTraceValidator : AbstractValidator<Trace>
{
    public PersistTraceValidator()
    {
        this.RuleFor(x => x.ExceptionId)
            .NotEmpty()
            .GreaterThanOrEqualTo(1);

        this.RuleFor(x => x.File)
            .NotEmpty()
            .MaximumLength(512);

        this.RuleFor(x => x.Method)
            .NotEmpty()
            .MaximumLength(512);
    }
}
