using Microsoft.EntityFrameworkCore;

namespace Quartz.Data;

public class RandomNumberDbContext : DbContext {
  public DbSet<RandomNumber> Numbers => Set<RandomNumber>();

  public RandomNumberDbContext(DbContextOptions<RandomNumberDbContext> options) : base(options) { }
}