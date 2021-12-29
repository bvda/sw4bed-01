using System;
using Microsoft.EntityFrameworkCore;

namespace multi_container.data 
{
  public class WeatherForecastDbContext : DbContext {

    public WeatherForecastDbContext() : base() { }
    public WeatherForecastDbContext (DbContextOptions<WeatherForecastDbContext> options)
                : base(options)
            {
            }

            public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().ToTable("WeatherForecast");
        }
      }
}