using MTGCollection.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<MongoService>(s => new MongoService(builder.Configuration.GetConnectionString("Localhost")));
builder.Services.AddSingleton<CardService>();
builder.Services.AddSingleton<DecksService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope =  app.Services.CreateScope()) 
{
    var services = scope.ServiceProvider;
    var cardService = services.GetRequiredService<CardService>();
    if(!await cardService.IsSeeded()) {
        cardService.SeedCards(new [] {"lea.json", "arn.json", "atq.json", "leg.json"});
    }
}

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
