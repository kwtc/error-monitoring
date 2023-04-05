namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Exception
{
    public int Id { get; set; }

    public Guid EventId { get; set; }

    public string Type { get; set; } = default!;

    public string Message { get; set; } = default!;
}
