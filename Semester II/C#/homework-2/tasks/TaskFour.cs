namespace tasks;

public class TaskFour
{
    public static void Run()
    {
        Console.Write("Enter the student's score (0-100): ");
        if (int.TryParse(Console.ReadLine(), out var score))
        {
            var result = EvaluateScore(score);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
        }
    }

    private static string EvaluateScore(int score)
    {
        return score switch
        {
            int n when n >= 0 && n <= 50 => "You’ve failed the exam... 😞",
            int n when n >= 51 && n <= 60 => "You’ve passed the exam. The result - E",
            int n when n >= 61 && n <= 70 => "You’ve passed the exam. The result - D",
            int n when n >= 71 && n <= 80 => "You’ve passed the exam. The result - C",
            int n when n >= 81 && n <= 90 => "You’ve passed the exam. The result - B",
            int n when n >= 91 && n < 100 => "You’ve passed the exam. The result - A",
            100 => "You’ve passed the exam. You’re an excellent student! The result - A",
            _ => "Invalid score. Please enter a number between 0 and 100."
        };
    }
}