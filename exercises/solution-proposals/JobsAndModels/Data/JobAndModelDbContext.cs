using Microsoft.EntityFrameworkCore;

using JobsAndModels.Models;

namespace JobsAndModels.Data;

public class JobsAndModelsDbContext : DbContext {
  public DbSet<Job> Jobs => Set<Job>();
  public DbSet<Model> Models => Set<Model>();

  public JobsAndModelsDbContext(DbContextOptions<JobsAndModelsDbContext> options) : base(options) { }

  
}
