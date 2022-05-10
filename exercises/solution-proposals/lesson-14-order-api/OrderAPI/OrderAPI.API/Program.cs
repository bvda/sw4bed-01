using Microsoft.EntityFrameworkCore;
using OrderAPI.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase("order.db"));
builder.Services.AddHostedService<OrderBackgroundService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
