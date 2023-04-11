using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using AutoMapperExample.Data;

namespace AutoMapperExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMapper _mapper;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var model1 = new Model1 {
            Property1 = 1,
            Property2 = "prop",
            Property3 = new Model2[] { new Model1 {
                Property1 = 11, 
                Property2 = "prop11",
                Property3 = null
            }}
        };
        _mapper<Model2>(model1);
        return new WeatherForecast[] {};
    }
}
