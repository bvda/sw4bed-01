using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using multi_container.data;

namespace multi_container.migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applying migrations");
            var webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<ConsoleStartup>()
                .Build();

            using (var context = (WeatherForecastDbContext) webHost.Services.GetService(typeof(WeatherForecastDbContext)))
            {
                context.Database.Migrate();
            }
            Console.WriteLine("Done");
        }
    }
}