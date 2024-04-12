namespace midterm;

class CelsiusToFahrenheitConverter : ITemperatureConverter
{
    public double ConvertTemperature(double temperature, string scale)
    {
        if (scale.ToLower() != "celsius")
            throw new ArgumentException("Invalid scale. This converter only supports converting from Celsius to Fahrenheit.");

        return (temperature * 9 / 5) + 32;
    }
}