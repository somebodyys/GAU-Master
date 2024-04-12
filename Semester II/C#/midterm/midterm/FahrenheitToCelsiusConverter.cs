namespace midterm;

public class FahrenheitToCelsiusConverter : ITemperatureConverter
{
    public double ConvertTemperature(double temperature, string scale)
    {
        if (scale.ToLower() != "fahrenheit")
            throw new ArgumentException("Invalid scale. This converter only supports converting from Fahrenheit to Celsius.");

        return (temperature - 32) * 5 / 9;
    }
}