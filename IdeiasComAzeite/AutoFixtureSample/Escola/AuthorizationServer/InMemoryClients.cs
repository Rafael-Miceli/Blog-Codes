using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace AuthorizationServer
{
    public class InMemoryClients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "teste",
                    ClientName = "Teste OAuth2",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.ResourceOwner,
                    AllowedScopes  = new List<string> { StandardScopes.OpenId.Name },
                    Enabled = true
                },
                new Client
                {
                    ClientId = "teste_implict",
                    ClientName = "Teste OAuth2 Implicit",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.Implicit,

                    AllowedScopes  = new List<string>
                    {
                         Constants.StandardScopes.OpenId,
                         Constants.StandardScopes.Profile,
                         "read"
                    },
                    RedirectUris = new List<string>
                    {
                        "http://localhost:50335"
                    },
                    Enabled = true
                }
            };
        }
    }
}