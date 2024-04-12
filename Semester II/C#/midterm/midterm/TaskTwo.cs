namespace midterm;

public class TaskTwo : TemperatureConverter
{
    public static void Run()
    {
        Console.WriteLine("Temperature Converter");
        Console.WriteLine("---------------------");
        Console.WriteLine("Enter the temperature:");
        
        double temperature = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Choose the conversion:");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        
        int choice = Convert.ToInt32(Console.ReadLine());
        
        double convertedTemperature = 0;
        switch (choice)
        {
            case 1:
                convertedTemperature = TemperatureConverter.CelsiusToFahrenheit(temperature);
                Console.WriteLine($"{temperature} Celsius is equal to {convertedTemperature} Fahrenheit");
                break;
            case 2:
                convertedTemperature = TemperatureConverter.FahrenheitToCelsius(temperature);
                Console.WriteLine($"{temperature} Fahrenheit is equal to {convertedTemperature} Celsius");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    public static void RunTwo()
    {
        ITemperatureConverter celsiusToFahrenheitConverter = new CelsiusToFahrenheitConverter();
        ITemperatureConverter fahrenheitToCelsiusConverter = new FahrenheitToCelsiusConverter();

        double celsiusTemperature = 30;
        double fahrenheitTemperature = 86;

        double convertedFahrenheit = celsiusToFahrenheitConverter.ConvertTemperature(celsiusTemperature, "Celsius");
        Console.WriteLine($"{celsiusTemperature} Celsius is equal to {convertedFahrenheit} Fahrenheit");
        
        double convertedCelsius = fahrenheitToCelsiusConverter.ConvertTemperature(fahrenheitTemperature, "Fahrenheit");
        Console.WriteLine($"{fahrenheitTemperature} Fahrenheit is equal to {convertedCelsius} Celsius");
    }
}