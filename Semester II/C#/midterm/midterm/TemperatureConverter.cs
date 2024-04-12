namespace midterm;

public class TemperatureConverter : ITemperatureConverter
{
    public double ConvertTemperature(double temperature, string scale)
    {
        switch (scale.ToLower())
        {
            case "c":
            case "celsius":
                return CelsiusToFahrenheit(temperature);
            case "f":
            case "fahrenheit":
                return FahrenheitToCelsius(temperature);
            default:
                throw new ArgumentException("Invalid temperature scale. Please use 'C' for Celsius or 'F' for Fahrenheit.");
        }
    }
    
    protected static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }
    
    protected static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}