namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using FluentValidation;
using Kwtc.ErrorMonitoring.Domain.Report;

public class PersistReportValidator : AbstractValidator<Report>
{
    public PersistReportValidator()
    {
        this.RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("ClientId cannot be empty");
    }
}
