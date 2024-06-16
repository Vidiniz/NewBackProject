using IdentityServer4.Models;

namespace ISolutions.NewBackProject.SSO.Features.Clients
{
    public static class ApiResourcesModel
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("isolutions-newbackproject-api")
            };
        }
    }
}
