var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.Use(async  (context, next) => {
    var protocol = context.Request.IsHttps;
    if (protocol) {
        await next(context);
    } else { 
        context.Response.StatusCode = 400;
        await context.Response.WriteAsJsonAsync(new { 
            message = "HTTP not supported. Use HTTPS.",
            status_code = 400
        });
        return; 
    }
});

app.UseAuthorization();

app.MapControllers();

app.Run();
