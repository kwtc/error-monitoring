namespace Kwtc.ErrorMonitoring.Application.Validation.Payload;

using FluentValidation;
using Kwtc.ErrorMonitoring.Application.Models.Report.Payload;

public class ExceptionPayloadValidator : AbstractValidator<ExceptionPayload>
{
    public ExceptionPayloadValidator()
    {
    }
}
