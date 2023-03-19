namespace Kwtc.ErrorMonitoring.Application.Validators;

using FluentValidation;
using Models;

public class ReportPayloadValidator : AbstractValidator<ReportPayload>
{
    public ReportPayloadValidator()
    {
        this.RuleFor(x => x.AppId).NotEmpty();
        this.RuleFor(x => x.OriginalException).NotNull();
    }
}
