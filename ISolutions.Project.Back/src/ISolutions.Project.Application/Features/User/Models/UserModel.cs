namespace ISolutions.Project.Application.Features.User.Models;
public class UserModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTimeOffset RegisterDate { get; set; }
}
