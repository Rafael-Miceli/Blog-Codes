using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace AuthorizationServer
{
    public class InMemoryScopes
    {
        public static IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "read",
                    DisplayName = "Leitura",
                    Type = ScopeType.Resource,
                    Emphasize = false,
                    AllowUnrestrictedIntrospection = true,
                    ScopeSecrets = new List<Secret> { new Secret("secret".Sha256()) }
                },
            };
        }
    }
}