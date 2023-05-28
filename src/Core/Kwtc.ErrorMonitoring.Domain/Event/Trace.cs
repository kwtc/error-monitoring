namespace Kwtc.ErrorMonitoring.Domain.Event;

public class Trace
{
    public int Id { get; set; }
    
    public int ExceptionId { get; set; }

    public string File { get; set; } = default!;

    public int LineNumber { get; set; }

    public string Method { get; set; } = default!;
}
