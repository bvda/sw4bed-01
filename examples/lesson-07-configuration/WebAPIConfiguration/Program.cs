using Microsoft.EntityFrameworkCore;

using WebAPIConfiguration.Data;
using WebAPIConfiguration.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
  builder.Services.AddDbContext<NetLogContext>(options =>
    options.UseInMemoryDatabase("NetLogDev"));
}
else
{
  builder.Services.AddDbContext<NetLogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NetLog")));
}

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

seedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void seedData() {
  using(var scope = app.Services.CreateScope()) {
  var context = scope.ServiceProvider.GetRequiredService<NetLogContext>();
    context.Database.EnsureCreated();
    context.NetLogs.Add(new NetLog { 
        ID = new Guid("ba0b2e46-f8ee-4c49-84ef-59877b6480c4"), 
        Source = "0.196.36.4",
        Destination = "239.136.66.100",
        UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_6_2) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/13.0.782.107 Safari/535.1", 
        Port = 55874,
        Date = DateTime.Parse("2021-08-17T13:14:56Z")
    });
    context.SaveChanges();
  }
}