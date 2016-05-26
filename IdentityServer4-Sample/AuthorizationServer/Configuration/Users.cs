using IdentityModel;
using IdentityServer4.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthorizationServer.Configuration
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            var users = new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "GUIDS",
                    Username = "rafael.miceli@oauth.com",
                    Password = "123456",
                    //Pequena mudança no nome do Claims comparado ao IdentityServe3
                    Claims = new []
                    {
                        new Claim(JwtClaimTypes.Name, "Rafael Miceli")
                    }
                }                
            };

            return users;
        }
    }
}