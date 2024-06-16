using ISolutions.NewBackProject.SSO.Features.Clients;

namespace ISolutions.NewBackProject.SSO.IdentityServer
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddIdentityServerService(this IServiceCollection services)
        {
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryClients(ClientModel.Clients())
                    .AddInMemoryIdentityResources(IdentityResourcesModel.IdentityResources()) 
                    .AddInMemoryApiResources(ApiResourcesModel.ApiResources());

            return services;
        }
    }
}
