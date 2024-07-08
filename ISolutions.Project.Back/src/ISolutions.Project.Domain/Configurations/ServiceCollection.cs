using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISolutions.Project.Domain.Configurations;
public static class ServiceCollection
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<PaginationConfiguration>()
                .Bind(configuration.GetSection(nameof(PaginationConfiguration)));

        return services;
    }
}
