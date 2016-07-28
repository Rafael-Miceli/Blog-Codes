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
            //JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
                CookieSecure = CookieSecureOption.Always
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "teste_implict",
                Authority = "https://localhost:44305/",
                RedirectUri = "http://localhost:50335",
                ResponseType = "id_token",
                SignInAsAuthenticationType = "Cookies"               
            });
        }
    }
}
