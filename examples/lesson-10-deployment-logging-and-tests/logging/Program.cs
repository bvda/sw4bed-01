using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Setup logging
builder.Host.UseSerilog((context, services, configuration) => {
    configuration.ReadFrom.Configuration(context.Configuration).Enrich.FromLogContext().WriteTo.Console();
});

builder.Services.AddCors(builder => builder.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

// Add services to the container.
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
app.UseCors();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
