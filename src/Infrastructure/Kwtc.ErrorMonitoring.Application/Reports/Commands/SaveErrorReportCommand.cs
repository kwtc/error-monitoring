namespace Kwtc.ErrorMonitoring.Application.Reports.Commands;

using Domain.Models;
using MediatR;
using Persistence.Abstractions.Reports;

public record SaveErrorReportCommand(Report Report) : IRequest<Report>;

internal sealed class SaveErrorReportCommandHandler : IRequestHandler<SaveErrorReportCommand, Report>
{
    private readonly IReportRepository reportRepository;

    public SaveErrorReportCommandHandler(IReportRepository reportRepository)
    {
        this.reportRepository = reportRepository;
    }

    public async Task<Report> Handle(SaveErrorReportCommand request, CancellationToken cancellationToken)
    {
        // TODO: validate report
        
        return await this.reportRepository.AddAsync(request.Report, cancellationToken);
    }
}
