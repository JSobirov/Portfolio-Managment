using Portfolio.Domain.Commons;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Portfolio.Domain.Entities;
#nullable disable

public class User : Auditable
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CardNumd { get; set; }
    public int Money { get; set; }
}