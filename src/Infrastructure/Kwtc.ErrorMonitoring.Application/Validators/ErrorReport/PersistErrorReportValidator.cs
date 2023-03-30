namespace Kwtc.ErrorMonitoring.Application.Validators.ErrorReport;

using Domain.ErrorReport;
using FluentValidation;

public class PersistErrorReportValidator : AbstractValidator<ErrorReport>
{
    public PersistErrorReportValidator()
    {
        // this.RuleFor(x => x.Exceptions)
        //     .NotEmpty()
        //     .WithMessage("Exceptions cannot be empty");
        //
        // this.RuleForEach(x => x.Exceptions)
        //     .SetValidator(new ExceptionValidator());
    }
}
