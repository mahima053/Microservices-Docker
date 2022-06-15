using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace OcelotApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                  //  var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(config =>
           config.AddJsonFile($"ocelot.route.json")
                    .AddJsonFile($"ocelot.global.json"));


                });
         /*   .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("ocelot.Development.json", optional: false, reloadOnChange: true);
            
            }); */
    }
}
