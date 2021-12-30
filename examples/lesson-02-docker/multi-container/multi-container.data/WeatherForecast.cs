using System;

namespace multi_container.data
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; } = string.Empty;

        public string NewSummary { get; set; } = string.Empty;
    }
}
