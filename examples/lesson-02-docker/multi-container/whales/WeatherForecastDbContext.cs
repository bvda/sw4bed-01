using System;
using Microsoft.EntityFrameworkCore;

namespace whales 
{
  public class WeatherForecastDbContext : DbContext {
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