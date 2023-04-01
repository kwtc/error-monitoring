namespace Kwtc.ErrorMonitoring.Application.Reports.Commands;

using Domain.Report;
using FluentValidation;
using MediatR;
using Persistence.Reports;
using Validators.ErrorReport;

public record PersistReportCommand(Guid ClientId, Report Report) : IRequest<Report>;

internal sealed class PersistReportCommandHandler : IRequestHandler<PersistReportCommand, Report>
{
    private readonly IErrorReportRepository errorReportRepository;

    public PersistReportCommandHandler(IErrorReportRepository errorReportRepository)
    {
        this.errorReportRepository = errorReportRepository;
    }

    public async Task<Report> Handle(PersistReportCommand request, CancellationToken cancellationToken)
    {
        await new PersistErrorReportValidator().ValidateAndThrowAsync(request.Report, cancellationToken);

        return await this.errorReportRepository.AddAsync(request.Report, cancellationToken);
    }
}
