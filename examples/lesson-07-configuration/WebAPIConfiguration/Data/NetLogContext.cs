using System.Text.Json;
using Microsoft.EntityFrameworkCore;

using WebAPIConfiguration.Model;

namespace WebAPIConfiguration.Data;

public class NetLogContext : DbContext {
  public DbSet<NetLog> NetLogs => Set<NetLog>();

  public NetLogContext(DbContextOptions<NetLogContext> options) : base(options) { }
}
