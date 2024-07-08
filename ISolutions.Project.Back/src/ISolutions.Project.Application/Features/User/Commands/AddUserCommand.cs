using ISolutions.Project.Application.Shared.Models;
using MediatR;

namespace ISolutions.Project.Application.Features.User.Commands;
public class AddUserCommand: IRequest<BaseModel>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
