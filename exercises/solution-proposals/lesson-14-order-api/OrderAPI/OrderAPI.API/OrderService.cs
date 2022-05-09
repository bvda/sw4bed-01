using Microsoft.EntityFrameworkCore;

namespace OrderAPI.API;

public interface IOrderService {
  Task<List<Order>> GetOrders();
  void CreateOrder(Order order);
  void ProcessOrders();
}

public class OrderService: IOrderService {

  private readonly OrderDbContext _context;

  public OrderService(OrderDbContext context) { 
    _context = context;
  }

  public async Task<List<Order>> GetOrders() {
    return await _context.Orders.ToListAsync();
  }

  public async void CreateOrder(Order order) {
    await _context.Orders.AddAsync(order);
    await _context.SaveChangesAsync();
  }

  public async void ProcessOrders() {
    _context.Orders.ToList().ForEach(o => {
      _context.Remove(o);  
    });
    await _context.SaveChangesAsync();
  }
}