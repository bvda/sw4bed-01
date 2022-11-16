using Microsoft.EntityFrameworkCore;

namespace OrderAPI.API;

public class OrderDbContext : DbContext {

  public DbSet<Order> Orders => Set<Order>();

  public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
}