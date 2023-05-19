namespace Kwtc.ErrorMonitoring.Application.Validation.Payload;

using Application.Report.Commands;
using FluentValidation;

public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        this.RuleFor(x => x.JsonContent)
            .NotEmpty()
            .WithMessage("Json content cannot be empty");
        this.RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("Client id cannot be empty");
    }
}
