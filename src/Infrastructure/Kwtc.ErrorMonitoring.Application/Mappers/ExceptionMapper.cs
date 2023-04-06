namespace Kwtc.ErrorMonitoring.Application.Mappers;

using Abstractions.Mapping;
using Domain.Report;
using Models.Report.Payload;

public class ExceptionMapper : IMapper<ExceptionPayload, Exception>
{
    public void Map(ExceptionPayload source, Exception target)
    {
        target.Type = source.Type;
        target.Message = source.Message;
    }
}
