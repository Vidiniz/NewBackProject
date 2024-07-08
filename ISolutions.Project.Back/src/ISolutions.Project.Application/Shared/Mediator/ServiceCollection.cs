using Microsoft.Extensions.DependencyInjection;

namespace ISolutions.Project.Application.Shared.Mediator;
public static class ServiceCollection
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceCollection).Assembly));

        return services;
    }
}
