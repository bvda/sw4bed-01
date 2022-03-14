using Microsoft.EntityFrameworkCore;

using UserSecrets.Model;

namespace UserSecrets.Data;

public class NetLogContext : DbContext {
  public DbSet<NetLog> NetLogs => Set<NetLog>();

  public NetLogContext(DbContextOptions<NetLogContext> options) : base(options) { }
}
