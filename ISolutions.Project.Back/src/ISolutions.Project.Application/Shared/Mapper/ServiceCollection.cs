using ISolutions.Project.Application.Shared.Mapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace ISolutions.Project.Application.Shared.Mapper;
public static class ServiceCollection
{
    public static IServiceCollection AddMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EntityToModelProfile));

        return services;
    }
}
