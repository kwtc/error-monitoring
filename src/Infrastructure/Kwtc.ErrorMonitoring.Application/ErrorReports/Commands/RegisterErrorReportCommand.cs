namespace Kwtc.ErrorMonitoring.Application.ErrorReports.Commands;

using Abstractions.Mapping;
using Domain.ErrorReport;
using FluentValidation;
using Models;
using Kwtc.ErrorMonitoring.Persistence.Abstractions.Reports;
using Mapping;
using MediatR;
using Validators;

public record RegisterErrorReportCommand(ReportPayload ReportPayload) : IRequest<ErrorReport>;

internal sealed class RegisterErrorReportCommandHandler : IRequestHandler<RegisterErrorReportCommand, ErrorReport>
{
    private readonly IMapper<ReportPayload, ErrorReport> mapper;
    private readonly IReportRepository reportRepository;

    public RegisterErrorReportCommandHandler(IMapper<ReportPayload, ErrorReport> mapper, IReportRepository reportRepository)
    {
        this.mapper = mapper;
        this.reportRepository = reportRepository;
    }

    public async Task<ErrorReport> Handle(RegisterErrorReportCommand request, CancellationToken cancellationToken)
    {
        await new ReportPayloadValidator().ValidateAndThrowAsync(request.ReportPayload, cancellationToken);

        return await this.reportRepository.AddAsync(this.mapper.MapNew(request.ReportPayload), cancellationToken);
    }
}
