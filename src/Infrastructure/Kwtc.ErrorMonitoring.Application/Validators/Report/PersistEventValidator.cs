namespace Kwtc.ErrorMonitoring.Application.Validators.Report;

using Domain.Report;
using FluentValidation;

public class PersistEventValidator : AbstractValidator<Event>
{
    public PersistEventValidator()
    {
        this.RuleFor(x => x.ReportId)
            .NotEmpty()
            .WithMessage("Report id cannot be empty");
        
        this.RuleFor(x => x.Exceptions)
            .NotEmpty()
            .WithMessage("Exceptions cannot be empty");
    }
}
