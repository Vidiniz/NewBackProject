using ISolutions.Project.Infrastructure.Repositories.Implementations;
using ISolutions.Project.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISolutions.Project.Infrastructure.Repositories;
public static class ServiceCollection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
