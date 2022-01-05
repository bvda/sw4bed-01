using System;
using multi_container.data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace multi_container.migrations
{
    public class ConsoleStartup
    {
        public ConsoleStartup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //.. for test
            Console.WriteLine(Configuration["ConnectionString"]);
        } 

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WeatherForecastDbContext>(options =>
            {
              options.UseSqlServer(Configuration["ConnectionString"]);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
       
        }
    }
}