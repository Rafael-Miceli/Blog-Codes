using IdentityServer4.Core.Models;
using System.Collections.Generic;

namespace AuthorizationServer.Configuration
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new []
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
                }
            };
        }
    }
}