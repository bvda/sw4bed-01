using Microsoft.EntityFrameworkCore;
using Lesson07_ContactsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
  builder.Services.AddDbContext<ContactContext>(options =>
    options.UseInMemoryDatabase("NetLogDev"));
}
else
{
  builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NetLogs")));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
