﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Http;
using Domain;
using Data;
using MongoData;

using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace api
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            IntegrateSimpleInjector(services);
            // services.AddTransient<IFeederService, FeederService>();
            // services.AddTransient<IFeederRepository, FeederSqlServerRepository>();
            // services.AddTransient<IFeederRepository, FeederMongoRepository>();
        }

        private void IntegrateSimpleInjector(IServiceCollection services) 
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);
            container.Verify();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void InitializeContainer(IApplicationBuilder app) 
        {
            
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            container.Register<IFeederService, FeederService>(Lifestyle.Scoped);
            // container.Register<IFeederRepository, FeederSqlServerRepository>(Lifestyle.Scoped);
            // SeedSqlServer();
            container.Register<IFeederRepository, FeederMongoRepository>(Lifestyle.Scoped);
            
        }

        private void SeedSqlServer()
        {
            Console.WriteLine("Seeding SqlServer");
            //using (var connection = new SqlConnection("Server=tcp:192.168.99.100,1433;Initial Catalog=master;User Id=sa;Password=whatever12!"))
            using (var connection = new SqlConnection("Server=tcp:localhost,1433;Initial Catalog=master;User Id=sa;Password=whatever12!"))
            {
                var command = new SqlCommand(@"
                    IF (NOT EXISTS (SELECT * 
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_SCHEMA = 'dbo' 
                    AND  TABLE_NAME = 'Feeder'))
                    BEGIN
                        CREATE TABLE dbo.Feeder (
                        ID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                        NAME TEXT NOT NULL
                        )
                    END
                    ", connection);
                connection.Open();                
                command.ExecuteNonQuery();
            }            
            Console.WriteLine("SqlServer Succefully Seeded!");
        }
    }
}
