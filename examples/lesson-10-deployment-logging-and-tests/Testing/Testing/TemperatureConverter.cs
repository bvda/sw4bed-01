namespace Testing;

public class TemperatureConverter {
  public decimal CelsiusToFahrenheit(decimal celcius) {
    if(celcius < kelvinToCelsius(0)) {
      throw new ArgumentOutOfRangeException(nameof(celcius));
    }
    return (celcius * 9/5) + 32; 
  } 

  public decimal kelvinToCelsius(decimal kelvin) {
    return kelvin - 273.15m;
  }
}