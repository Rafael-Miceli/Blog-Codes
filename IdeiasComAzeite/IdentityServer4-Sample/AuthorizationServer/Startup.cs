using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;
using AuthorizationServer.Configuration;

namespace AuthorizationServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var certificado = Convert.FromBase64String("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");
            
            var cert = new X509Certificate2(certificado, "password");
            
            var identityServerBuilder = services.AddIdentityServer(options =>
            {
                options.SigningCertificate = cert;
            });
            
            identityServerBuilder.AddInMemoryClients(Clients.Get());
            identityServerBuilder.AddInMemoryScopes(Scopes.Get());
            identityServerBuilder.AddInMemoryUsers(Users.Get());
            
            services.AddMvc()
            .AddRazorOptions(razor =>
                {
                    razor.ViewLocationExpanders.Add(new AuthorizationServer.UI.CustomViewLocationExpander());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
