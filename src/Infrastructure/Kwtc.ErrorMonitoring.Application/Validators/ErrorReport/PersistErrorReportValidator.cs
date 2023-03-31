namespace Kwtc.ErrorMonitoring.Application.Validators.ErrorReport;

using Domain.Report;
using FluentValidation;

public class PersistErrorReportValidator : AbstractValidator<Report>
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
