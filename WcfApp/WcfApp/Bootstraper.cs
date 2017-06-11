using Autofac;
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
            return builder.Build();
        }
    }
}