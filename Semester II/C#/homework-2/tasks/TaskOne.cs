namespace tasks;

public class TaskOne
{
    public static void Run()
    {
        Console.WriteLine("Enter a number for a month (1-12):");
        var input = Console.ReadLine();
        var month = input != null && int.TryParse(input, out var parsedMonth) ? parsedMonth : -1;

        var message = month != -1 ? 
            GetSeasonMessage(month) :
            "Invalid input. Please enter a number.";

        Console.WriteLine(message);
    }
    
    private static string GetSeasonMessage(int month)
    {
        var season = GetSeason(month);
        return season != "" ?
            $"The corresponding season is: {season}" :
            "Invalid month number entered.";
    }
    
    private static string GetSeason(int month)
    {
        switch (month)
        {
            case 12:
            case 1:
            case 2:
                return "Winter";
            case 3:
            case 4:
            case 5:
                return "Spring";
            case 6:
            case 7:
            case 8:
                return "Summer";
            case 9:
            case 10:
            case 11:
                return "Autumn";
            default:
                return "";
        }
    }
}