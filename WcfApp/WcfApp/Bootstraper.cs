using Autofac;
using System;
using System.Net;
using System.ServiceModel.Web;
using WcfApp.Contracts;
using WcfApp.Services;

namespace WcfApp
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AlunoService>().As<IAlunoServiceContract>();
            builder.RegisterType<AlunoApplicationService>().As<IAlunoApplicationService>();

            builder.Register(r => BuildDbRepo()).As<IAlunoRepoToAnyDb>();

            return builder.Build();
        }

        private static AlunoRepoToAnyDb BuildDbRepo()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;

            var clientToken = headers["clientToken"];

            var clientClaim = GetClientClaimFromToken(clientToken);

            var connStringDb = MontarConn(clientClaim);

            return new AlunoRepoToAnyDb(connStringDb);
        }

        private static string GetClientClaimFromToken(string clientToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ReadToken(clientToken) as JwtSecurityToken;

            return principal.Claims.FirstOrDefault(c => c.Type == "client_id").Value;
        }

        private static string MontarConn(string clientClaim)
        {   
            if (clientClaim == "Client1")
            {
                return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlunosClient1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }

            if (clientClaim == "Client2")
            {
                return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlunosClient2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; ;
            }

            throw new Exception("Not a valid client token");
        }
    }
}