using System;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                .WithGlobalConnectionString(Environment.GetEnvironmentVariable("DATABASES__SQLSERVER__CONNECTIONSTRING"))
                           .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
                
        } 

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var config =
                        new ConfigurationBuilder()
                              .AddEnvironmentVariables()
                               .Build();


                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                });
    }
}
