using FluentValidation;
using ISolutions.Project.Application.Features.User.Commands;
using ISolutions.Project.Application.Features.User.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace ISolutions.Project.Application.Features.User;
public static class ServiceCollection
{
    public static IServiceCollection AddUser(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AddUserCommand>, AddUserCommandValidation>();
        return services;
    }
}
