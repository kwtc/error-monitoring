namespace Kwtc.ErrorMonitoring.Application.Validators.Payload;

using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Models.Report;

public class ExceptionPayloadValidator : AbstractValidator<ExceptionPayload>
{
    public ExceptionPayloadValidator()
    {
    }
}
