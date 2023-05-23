namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using FluentValidation;
using Reports.Commands;

public class PersistReportCommandValidator : AbstractValidator<PersistReportCommand>
{
    public PersistReportCommandValidator()
    {
        this.RuleFor(x => x.Report)
            .NotNull()
            .WithMessage("Report cannot be null");
        this.RuleFor(x => x.Report.ClientId)
            .NotEmpty()
            .WithMessage("ClientId cannot be empty");
        this.RuleFor(x => x.Report.Event)
            .NotNull()
            .WithMessage("Event cannot be null");
    }
}
