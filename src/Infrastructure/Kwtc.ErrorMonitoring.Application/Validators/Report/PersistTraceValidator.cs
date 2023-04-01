namespace Kwtc.ErrorMonitoring.Application.Validators.Report;

using Domain.Report;
using FluentValidation;

public class PersistTraceValidator : AbstractValidator<Trace>
{
    public PersistTraceValidator()
    {
        this.RuleFor(x => x.ExceptionId)
            .NotEmpty()
            .WithMessage("Exception id cannot be empty");

        this.RuleFor(x => x.File)
            .NotEmpty()
            .WithMessage("File cannot be empty");

        this.RuleFor(x => x.Method)
            .NotEmpty()
            .WithMessage("Method cannot be empty");
    }
}
