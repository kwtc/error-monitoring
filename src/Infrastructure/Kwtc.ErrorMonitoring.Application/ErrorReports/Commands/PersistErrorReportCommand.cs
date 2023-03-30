namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Commands;

using Domain.ErrorReport;
using FluentValidation;
using MediatR;
using Persistence.Reports;
using Validators.ErrorReport;

public record PersistErrorReportCommand(ErrorReport ErrorReport) : IRequest<ErrorReport>;

internal sealed class RegisterErrorReportCommandHandler : IRequestHandler<PersistErrorReportCommand, ErrorReport>
{
    private readonly IErrorReportRepository errorReportRepository;

    public RegisterErrorReportCommandHandler(IErrorReportRepository errorReportRepository)
    {
        this.errorReportRepository = errorReportRepository;
    }

    public async Task<ErrorReport> Handle(PersistErrorReportCommand request, CancellationToken cancellationToken)
    {
        await new PersistErrorReportValidator().ValidateAndThrowAsync(request.ErrorReport, cancellationToken);

        return await this.errorReportRepository.AddAsync(request.ErrorReport, cancellationToken);
    }
}
