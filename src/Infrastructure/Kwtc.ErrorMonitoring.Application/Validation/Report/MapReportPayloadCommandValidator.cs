namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Report.Commands;

public class MapReportPayloadCommandValidator : AbstractValidator<MapReportPayloadCommand>
{
    public MapReportPayloadCommandValidator()
    {
        this.RuleFor(x => x.JsonContent)
            .NotEmpty()
            .WithMessage("Json content cannot be empty");
        this.RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("Client id cannot be empty");
    }
}
