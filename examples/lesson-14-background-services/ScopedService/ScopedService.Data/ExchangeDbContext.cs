using Microsoft.EntityFrameworkCore;

namespace ScopedService.Data;

public class ExchangeDbContext : DbContext
{
  public DbSet<Currency> Currencies => Set<Currency>();

  public ExchangeDbContext() { }
  public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options) : base(options) {

  }
}
