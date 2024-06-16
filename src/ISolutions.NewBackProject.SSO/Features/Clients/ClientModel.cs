using IdentityServer4.Models;

namespace ISolutions.NewBackProject.SSO.Features.Clients
{
    public static class ClientModel
    {
        public static IEnumerable<Client> Clients()
        {
            return new List<Client>
            {
                new Client
                {
                   ClientId = "isolutions-newbackproject-api",
                   ClientName = "New Back Project",
                   ClientSecrets = [ new Secret("segredo".Sha256()) ],
                   AllowedGrantTypes = GrantTypes.Code,
                   RedirectUris = [ "http://localhost:54442" ],
                   AllowedScopes = [ "openid", "profile", "email"  ]
                }
            };
        }
    }
}
