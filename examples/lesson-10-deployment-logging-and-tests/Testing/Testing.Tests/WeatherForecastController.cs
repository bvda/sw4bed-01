using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Testing.Tests;

public class WeatherForecastControllerTests
{
  [Theory]
  [InlineData(0, 32)]
  [InlineData(-273.15, -459.67)]
  public async Task PostWeatherForecastSuccess(decimal input, decimal output)
  {
    var application = new WebApplicationFactory<Program>()
      .WithWebHostBuilder(builder => { });

    var client = application.CreateClient();
    var body = JsonContent.Create(new { value = input });
    var response = await client.PostAsync("/weatherforecast", body);
    response.EnsureSuccessStatusCode();
    Assert.Equal(output.ToString(), await response.Content.ReadAsStringAsync());
  }

  [Fact]
  public async Task PostWeatherForecastBadRequest()
  {
    var input = -274;

    var application = new WebApplicationFactory<Program>()
      .WithWebHostBuilder(builder => { });

    var client = application.CreateClient();
    var body = JsonContent.Create(new { value = input });
    var response = await client.PostAsync("/weatherforecast", body);
    
    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }
}