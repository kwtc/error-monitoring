namespace Kwtc.ErrorMonitoring.Application.Validators.Payload;

using FluentValidation;
using Models.Report.Payload;

public class ReportPayloadValidator : AbstractValidator<ReportPayload>
{
    public ReportPayloadValidator()
    {
        this.RuleFor(x => x.Event)
            .NotEmpty()
            .WithMessage("Event cannot be empty");
    }
}
