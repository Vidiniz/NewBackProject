using ISolutions.Project.Domain.Constants;
using ISolutions.Project.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISolutions.Project.Infrastructure.Database;
public static class ServiceCollection
{
    public static IServiceCollection AddProjectContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ApplicationsConstants.SolutionsDb);

        services.AddDbContext<SolutionsContext>(
            options => options.UseSqlServer(connectionString));

        return services;
    }
}
