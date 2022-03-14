using Microsoft.EntityFrameworkCore;
using UserSecrets.Data;
using UserSecrets.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appSecrets = builder.Configuration.GetSection("ConnectionStrings").Get<AppSecretOptions>();
Console.WriteLine(appSecrets.NetLog);

if(appSecrets.NetLog is not null) {
    builder.Services.AddDbContext<NetLogContext>(options =>
        options.UseSqlServer(appSecrets.NetLog));
}

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
