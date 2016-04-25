using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

[assembly: OwinStartup(typeof(Escola.Api.Startup))]

namespace Escola.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "teste_implict",
                Authority = "http://localhost:54734/",
                RedirectUri = "http://localhost:50335",
                ResponseType = "id_token token",
                Scope = "openid profile",
                SignInAsAuthenticationType = "cookies"               
            });
        }
    }
}
