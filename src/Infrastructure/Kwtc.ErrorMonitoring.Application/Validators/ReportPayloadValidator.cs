namespace Kwtc.ErrorMonitoring.Application.Validators;

using FluentValidation;
using Models.Report;

public class ReportPayloadValidator : AbstractValidator<ReportPayload>
{
    public ReportPayloadValidator()
    {
        // validate that app is can be parsed to a GUID if it's not null or empty
        this.When(x => !string.IsNullOrEmpty(x.AppId), () =>
        {
            this.RuleFor(x => x.AppId)
                .Must(id => Guid.TryParse(id, out _))
                .WithMessage("AppId must be a valid GUID");
        });

        this.RuleFor(x => x.Event)
            .NotEmpty()
            .WithMessage("Event cannot be empty");
    }
}
