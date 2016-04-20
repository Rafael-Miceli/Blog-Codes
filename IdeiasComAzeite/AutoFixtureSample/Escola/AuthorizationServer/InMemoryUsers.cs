using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthorizationServer
{
    public class InMemoryUsers
    {
        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "GUIDS",
                    Username = "rafael.miceli@oauth.com",
                    Password = "123456",
                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.Name, "Rafael Miceli")
                    }
                }
            };
        }
    }
}