using FluentValidation;
using ISolutions.Project.Application.Features.User.Commands;

namespace ISolutions.Project.Application.Features.User.Validations;
public class AddUserCommandValidation: AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidation()
    {
        
    }
}
