namespace Kwtc.ErrorMonitoring.Application.Validation.Payload;

using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Models.Report.Payload;

public class ReportPayloadValidator : AbstractValidator<ReportPayload>
{
    public ReportPayloadValidator()
    {
        this.RuleFor(x => x.Event)
            .NotEmpty()
            .WithMessage("Event cannot be empty");
    }
}
