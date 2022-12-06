using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ScopedService.Data;

public class ExchangeDbContext : DbContext
{
  public DbSet<Currency> Currencies => Set<Currency>();
  
  public ExchangeDbContext() { }
  public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options) : base(options) { }

}
