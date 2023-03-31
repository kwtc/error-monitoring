namespace Kwtc.ErrorMonitoring.Domain.Report;

public class Exception
{
    public string Type { get; set; } = default!;

    public string Message { get; set; } = default!;

    public List<Trace> Trace { get; set; } = new();
}
