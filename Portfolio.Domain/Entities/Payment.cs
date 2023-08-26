using Portfolio.Domain.Commons;

namespace Portfolio.Domain.Entities;

public class Payment : Auditable
{
    public string FromCard { get; set; }
    public User FromUser { get; set; }

    public string ToCard { get; set; }
    public User  toUser { get; set; }

    public int Sum { get; set; }
}