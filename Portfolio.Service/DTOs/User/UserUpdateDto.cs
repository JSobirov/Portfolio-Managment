namespace Portfolio.Service.DTOs.User;

public class UserUpdateDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}