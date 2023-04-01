namespace Kwtc.ErrorMonitoring.Application.Validators;

using FluentValidation;
using Kwtc.ErrorMonitoring.Domain.Report;

public class PersistReportValidator : AbstractValidator<Report>
{
    public PersistReportValidator()
    {
        this.RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("ClientId cannot be empty");

        this.RuleFor(x => x.Event)
            .NotEmpty()
            .WithMessage("Event cannot be empty");
    }
}
