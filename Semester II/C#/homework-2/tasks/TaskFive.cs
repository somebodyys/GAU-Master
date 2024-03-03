namespace tasks;

public class TaskFive
{
    public static void Run()
    {
        Console.Write("Enter the amount in Georgian Lari: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.Write("Enter the currency you want to convert to (D for Dollar, E for Euro, P for Pound): ");
            var currency = Console.ReadLine()?.ToUpper();

            double convertedAmount = ConvertCurrency(amount, currency);
            if (convertedAmount != -1)
            {
                Console.WriteLine($"Converted amount: {convertedAmount} {currency}");
            }
            else
            {
                Console.WriteLine("Invalid currency selection.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for amount. Please enter a valid number.");
        }
    }
    
    private static double ConvertCurrency(double amount, string currency)
    {
        double exchangeRate;
        switch (currency)
        {
            case "D":
                exchangeRate = 0.30;
                break;
            case "E":
                exchangeRate = 0.25;
                break;
            case "P":
                exchangeRate = 0.20;
                break;
            default:
                return -1;
        }

        if (amount < 0)
        {
            return -1;
        }

        return amount * exchangeRate;
    }
}