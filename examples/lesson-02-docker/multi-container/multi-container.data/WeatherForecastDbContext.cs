using System;
using Microsoft.EntityFrameworkCore;

namespace multi_container.data 
{
  public class WeatherForecastDbContext : DbContext {

    public WeatherForecastDbContext (DbContextOptions<WeatherForecastDbContext> options)
                : base(options)
            {
            }

            public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().ToTable("WeatherForecast");
        }
      }
}