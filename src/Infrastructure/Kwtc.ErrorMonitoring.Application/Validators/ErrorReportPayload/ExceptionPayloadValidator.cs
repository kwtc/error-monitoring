namespace Kwtc.ErrorMonitoring.Application.Validators.ErrorReportPayload;

using FluentValidation;
using Models.Report;

public class ExceptionPayloadValidator : AbstractValidator<ExceptionPayload>
{
    public ExceptionPayloadValidator()
    {
    }
}
