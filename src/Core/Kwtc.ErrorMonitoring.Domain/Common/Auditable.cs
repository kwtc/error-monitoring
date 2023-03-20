namespace Kwtc.ErrorMonitoring.Domain.Common;

public class Auditable
{
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
