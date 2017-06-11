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

            var connStringDb = MontarConn(clientToken);

            return new AlunoRepoToAnyDb(connStringDb);
        }

        private static string MontarConn(string clientToken)
        {
            if (clientToken == "Token1")
            {
                return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlunosClient1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }

            if (clientToken == "Token2")
            {
                return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlunosClient2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; ;
            }

            throw new Exception("Not a valid client token");
        }
    }
}