using System;
using FinancialData.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancialData.API.Data
{
  public class DataContext : IdentityDbContext<AppUser>
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      // Called first - in this case, for Identity
      base.OnModelCreating(builder);

      builder.Entity<WeatherForecast>()
        .HasData(
          new WeatherForecast
          {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureC = 32,
            Summary = "It's hot!"
          },
          new WeatherForecast
          {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureC = 10,
            Summary = "It's chilly..."
          },
          new WeatherForecast
          {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureC = 0,
            Summary = "It's cold!"
          }
        );
    }
  }
}