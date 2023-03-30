namespace Kwtc.ErrorMonitoring.Application.Validators;

using ErrorReportPayload;
using FluentValidation;

public class ReportPayloadValidator : AbstractValidator<Models.Payload.ErrorReport.ErrorReportPayload>
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
