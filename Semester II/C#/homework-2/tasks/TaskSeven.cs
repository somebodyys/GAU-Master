namespace tasks;

public class TaskSeven
{
    public static void Run()
    {
       DisplaySquareNumbers(10);
    }
    
    private static void DisplaySquareNumbers(int n)
    {
        Console.WriteLine("___________________");
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"{i}\t\t{i * i}");
        }
        Console.WriteLine("___________________");
    }
}