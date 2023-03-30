namespace Kwtc.ErrorMonitoring.Application.Validators.ErrorReportPayload;

using FluentValidation;
using Models.Payload.ErrorReport;

public class ErrorReportPayloadValidator : AbstractValidator<ErrorReportPayload>
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
