using Xunit;
using InMemDb.Controllers;
using InMemDb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using InMemDb.Models;
using System.Linq;

namespace InMemDbTest
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dotnet-core.html
    public class ClientsTest
    {       
        
        [Fact]
        public void Given_A_Client_With_A_Cnpj_That_Doesnt_Exists_When_Adding_To_Database_Then_Persist_It()
        {
            //Arrange
            var options = CreateNewContextOptions();
            CriarMassaDeClient(options);            
            string result;

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var sut = new HomeController(context);
                result = sut.CreateClient(new Client {
                    Name = "Cliente vindo do teste",
                    Cnpj = "654321"
                });
            }            

            //Assert
            using (var context = new ApplicationDbContext(options))
            {
                Assert.Equal("Funfou", result);
                Assert.NotNull(context.Clients.FirstOrDefault(c => c.Cnpj == "654321"));                
            }            
        }

        private static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        private static void CriarMassaDeClient(DbContextOptions<ApplicationDbContext> options)
        {
            using (var context = new ApplicationDbContext(options))
            {
                var client = new Client {
                    Name = "Cliente de Teste 1",
                    Cnpj = "123456"
                };

                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

    }
}
