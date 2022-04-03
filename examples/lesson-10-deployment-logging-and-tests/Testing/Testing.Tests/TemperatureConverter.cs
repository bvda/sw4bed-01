using System;
using Xunit;

namespace Testing.Tests;

public class TemperatureConverterUnitTest
{
    [Fact]
    public void CelsiusToFahrenheit()
    {
        var converter = new TemperatureConverter();
        decimal input = 0;
        decimal expected = 32m;
        var actual = converter.CelsiusToFahrenheit(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CelsiusToFahrenheitBelowAbsoluteZero() {
        var converter = new TemperatureConverter();
        decimal input = -273.16m;
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => converter.CelsiusToFahrenheit(input)
        );
    }
}