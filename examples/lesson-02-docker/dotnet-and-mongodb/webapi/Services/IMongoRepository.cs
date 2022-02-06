namespace webapi.Services;

public interface IMongoRepository
{
  public Task Create(WeatherForecast forecast)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<WeatherForecast>> GetAll() {
    throw new NotImplementedException();
  }

}