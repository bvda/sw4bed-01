using Microsoft.EntityFrameworkCore;

using Quartz;
using Quartz.API;
using Quartz.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("QuartzDB");
// Add services to the container.
builder.Services.AddDbContext<RandomNumberDbContext>(
    opts => opts
        .UseSqlServer(connectionString,
        x => x.MigrationsAssembly("Quartz.Migration"))
);
builder.Services.AddQuartz(
    q => {
        q.UseMicrosoftDependencyInjectionJobFactory();
        var keyWrite = new JobKey("WriteRandomNumberJob");
        var keyCount = new JobKey("CountRandomNumberJob");
        q.AddJob<WriteRandomNumberJob>(keyWrite);
        q.AddTrigger(opts => opts
            .ForJob(keyWrite)
            .WithIdentity(keyWrite.Name)
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithInterval(TimeSpan.FromSeconds(5))
                .RepeatForever()));
        q.AddJob<CountRandomNumberJob>(keyCount);
        q.AddTrigger(opts => opts
            .ForJob(keyCount)
            .WithIdentity(keyCount.Name)
            .StartAt(new DateTimeOffset(DateTime.Now.AddSeconds(10)))
            .WithSimpleSchedule(x => x
                .WithInterval(TimeSpan.FromSeconds(5))
                .RepeatForever()));
        q.UsePersistentStore(s => {
            s.UseSqlServer(connectionString);
            s.UseClustering();
            s.UseProperties = true;
            s.UseJsonSerializer();
        });
    }
);

builder.Services.AddQuartzHostedService(
    q => q.WaitForJobsToComplete = true
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<RandomNumberDbContext>();
  db.Database.Migrate();
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
