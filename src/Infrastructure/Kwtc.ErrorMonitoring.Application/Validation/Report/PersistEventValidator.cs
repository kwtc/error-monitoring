namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using FluentValidation;
using Kwtc.ErrorMonitoring.Domain.Report;

public class PersistEventValidator : AbstractValidator<Event>
{
    public PersistEventValidator()
    {
        this.RuleFor(x => x.ReportId)
            .NotEmpty()
            .WithMessage("Report id cannot be empty");
    }
}
