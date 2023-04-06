namespace Kwtc.ErrorMonitoring.Application.Validators.Payload;

using FluentValidation;
using Models.Report.Payload;

public class ExceptionPayloadValidator : AbstractValidator<ExceptionPayload>
{
    public ExceptionPayloadValidator()
    {
    }
}
