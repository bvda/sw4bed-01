using Lists.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Setup logging
builder.Host.UseSerilog((context, services, configuration) => {
    configuration.ReadFrom.Configuration(context.Configuration).Enrich.FromLogContext().WriteTo.Console();
});

// Add services to the container.
builder.Services.AddSingleton<ListService<string>>();
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

public partial class Program { }
