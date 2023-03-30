namespace Kwtc.ErrorMonitoring.Application.Validators.ErrorReportPayload;

using FluentValidation;
using Models.Payload.ErrorReport;

public class ExceptionPayloadValidator : AbstractValidator<ExceptionPayload>
{
    public ExceptionPayloadValidator()
    {
    }
}
