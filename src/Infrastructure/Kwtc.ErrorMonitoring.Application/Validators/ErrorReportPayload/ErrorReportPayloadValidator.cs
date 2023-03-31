namespace Kwtc.ErrorMonitoring.Application.Validators.ErrorReportPayload;

using FluentValidation;
using Models.Report;

public class ErrorReportPayloadValidator : AbstractValidator<ReportPayload>
{
    public ErrorReportPayloadValidator()
    {
        // this.RuleFor(x => x.Exceptions)
        //     .NotEmpty()
        //     .WithMessage("Exceptions cannot be empty");

        // this.RuleForEach(x => x.Exceptions)
        //     .SetValidator(new ExceptionValidator());
    }
}
