namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using Application.Report.Queries;
using FluentValidation;

public class GetReportResponseByClientIdAndAppIdQueryValidator : AbstractValidator<GetReportResponseByClientIdAndAppIdQuery>
{
    public GetReportResponseByClientIdAndAppIdQueryValidator()
    {
        this.RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("ClientId is required.");

        this.RuleFor(x => x.AppId)
            .NotEmpty()
            .When(x => x.AppId.HasValue)
            .WithMessage("AppId is required to have a valid value when provided.");
    }
}
