namespace webapi;
using MongoDB.Bson;
using MongoDB.Driver;

public class WeatherForecast
{
    public ObjectId Id { get; set; }
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
