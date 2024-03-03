namespace tasks;

public class TaskTwo
{
    public static void Run()
    {
        Console.Write("Enter a number representing a day of the week (1-7): ");
        if (int.TryParse(Console.ReadLine(), out var dayNumber))
        {
            var result = GetDayType(dayNumber);
            Console.WriteLine($"The day is {result}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
        }
    }
    
    private static string GetDayType(int dayNumber)
    {
        switch (dayNumber)
        {
            case 1: // Monday
            case 2: // Tuesday
            case 3: // Wednesday
            case 4: // Thursday
            case 5: // Friday
                return "a working weekday";
            case 6: // Saturday
                return "Saturday";
            case 7: // Sunday
                return "Sunday";
            default:
                return "an invalid day";
        }
    }
}