using System.Text.Json;
using Microsoft.EntityFrameworkCore;

using UserSecrets.Model;

namespace UserSecrets.Data;

public class NetLogContext : DbContext {
  public DbSet<NetLog> NetLogs { get; set; }

  public NetLogContext(DbContextOptions<NetLogContext> options) : base(options) { }
}
