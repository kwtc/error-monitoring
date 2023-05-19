namespace Kwtc.ErrorMonitoring.Application.Validation.Payload;

using Application.Report.Commands;
using FluentValidation;

public class DeserializeReportPayloadCommandValidator : AbstractValidator<DeserializeReportPayloadCommand>
{
    public DeserializeReportPayloadCommandValidator()
    {
        this.RuleFor(x => x.Json)
            .NotEmpty()
            .WithMessage("Json content cannot be empty");
    }
}
