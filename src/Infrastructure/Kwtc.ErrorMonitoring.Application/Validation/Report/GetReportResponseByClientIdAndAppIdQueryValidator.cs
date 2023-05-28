namespace Kwtc.ErrorMonitoring.Application.Validation.Report;

using FluentValidation;
using Reports.Queries;

public class GetReportResponseByClientIdAndAppIdQueryValidator : AbstractValidator<GetEventsByClientIdAndAppIdQuery>
{
    public GetReportResponseByClientIdAndAppIdQueryValidator()
    {
        this.RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("ClientId is required.");

        this.RuleFor(x => x.AppId)
            .NotEmpty()
            .WithMessage("AppId is required.");
    }
}
