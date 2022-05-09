# Lesson 14 exercises
## Background Services
We will implement a simple queue for an order system, where orders are stored in memory and written to a database at a fixed interval.

## Exercise 14-01 
### Set up a new Web API
Create a new Web API with a `OrdersController` with the following end point:
- `GET /` - returns a list of `Order` objects
- `POST /` – creates an `Order`

Just return some mock data for now, we'll add a database later

You can use this model, or create your own:
```cs
public class Order {
  public int ID { get; set; }
  public DateTime Date { get; set; }
  public string Description { get; set; }
}
```

## Exercise 14-02
### Add a service for handling orders
Add an `OrderService` to the project with the following interface:

```cs
public interface IOrderService {
  Task<List<Order>> GetOrders();
  void CreateOrder(Order order);
  void ProcessOrders();
}
```

Inject `OrderService` into `OrdersController` and update the `POST` method, so it uses the service

## Exercise 14-03
### Add a Database
1. Set up a `OrderDbContext` with a set of `Order` objects (you can use `localdb`, an In-memory database, or spin up an SQL Server in Docker)
1. Inject `OrderDbContext` into `OrderService` and update the `GET` method, so it returns all `Order` objects from `OrderDbContext` by using `IOrderService`.

## Exercise 14-04
### Add a `BackgroundService` for processing orders
Add a `OrderBackgroundService` to your project to handle the orders.

1. Create the class file in your project
2. Inject `IServiceProvider` in the constructor and create a scope  to create an instance of `IOrderService`
3. Remove all `Orders` from `OrderDbContext` by using the `IOrderService` instance
4. The task should run every ten (10) seconds