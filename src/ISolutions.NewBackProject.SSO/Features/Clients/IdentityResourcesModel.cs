using IdentityServer4.Models;

namespace ISolutions.NewBackProject.SSO.Features.Clients
{
    public static class IdentityResourcesModel
    {
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
    }
}
