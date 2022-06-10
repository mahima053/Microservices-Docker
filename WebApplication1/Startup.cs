﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication1.DataContex;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var secret = configuration["SUPER_SECRET"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
         //   services.AddDbContext<CustomerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Server=db;Database=CustomerDb;User=sa;Password=Your_password123")));
            services.AddDbContext<CustomerContext>((options) => options.UseSqlServer("Server=db;Database=CustomerDb;User=sa;Password=Your_password123",
                (builder) => builder.MigrationsAssembly(typeof(Startup).Assembly.ToString())));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

        /*    services.AddFluentMigratorCore()
                .ConfigureRunner(config =>
                config.AddSqlServer()
                .WithGlobalConnectionString("Server=localhost;Database=CustomerDb;User=sa;Password=Your_password123")
                            .ScanIn(Assembly.GetExecutingAssembly()).For.All())
                .AddLogging(config => config.AddFluentMigratorConsole());  */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         /*   if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } */
             
        //    app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        /*    using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator.MigrateUp();  */

        }
    }
}
