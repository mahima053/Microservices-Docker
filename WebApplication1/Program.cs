using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication1.DataContex;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var serviceProvider = CreateServices();
            using (var scope = serviceProvider.CreateScope())
            {
               UpdateDatabase(scope.ServiceProvider);

           }
            CreateHostBuilder(args).Build().Run();
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            try
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "NOT FOUND");
            }
        } 

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()

                .AddFluentMigratorCore()
                .ConfigureRunner(config =>
                config.AddSqlServer()
                .WithGlobalConnectionString("Server=db;Database=CustomerDb;User=sa;Password=Your_password123;")
                           .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
                
        } 

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                });
    }
}
