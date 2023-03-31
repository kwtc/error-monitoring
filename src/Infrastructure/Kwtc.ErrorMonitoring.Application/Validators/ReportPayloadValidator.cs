namespace Kwtc.ErrorMonitoring.Application.Validators;

using ErrorReportPayload;
using FluentValidation;
using Models.Report;

public class ReportPayloadValidator : AbstractValidator<ReportPayload>
{
    public ReportPayloadValidator()
    {
        // this.RuleFor(x => x.Exceptions)
        //     .NotEmpty()
        //     .WithMessage("Exceptions cannot be empty");

        // this.RuleForEach(x => x.Exceptions)
        //     .SetValidator(new ExceptionPayloadValidator());
    }
}
