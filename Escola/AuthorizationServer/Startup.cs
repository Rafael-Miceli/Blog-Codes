using System;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

[assembly: OwinStartup(typeof(AuthorizationServer.Startup))]

namespace AuthorizationServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryScopes(InMemoryScopes.GetScopes())
                .UseInMemoryClients(InMemoryClients.GetClients())
                .UseInMemoryUsers(InMemoryUsers.GetUsers());

            string file = string.Format(@"{0}\Certs\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory);
           
            var options = new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(file, "idsrv3test"),
                RequireSsl = false,
                Factory = factory
            };

            app.UseIdentityServer(options);
        }
    }
}
