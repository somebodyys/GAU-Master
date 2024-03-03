namespace tasks;

public class TaskSix
{
    public static void Run()
    {
        Console.Write("Enter a natural number: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            bool isArithmeticProgression = CheckArithmeticProgression(number);
            Console.WriteLine(isArithmeticProgression ? "The digits of the number form an arithmetic progression." : "The digits of the number do not form an arithmetic progression.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid natural number.");
        }
    }
    
    private static bool CheckArithmeticProgression(int number)
    {
        string numberString = number.ToString();
        
        for (int i = 2; i < numberString.Length; i++)
        {
            int firstDigit = numberString[i - 2] - '0';
            int secondDigit = numberString[i - 1] - '0';
            int thirdDigit = numberString[i] - '0';

            if (secondDigit - firstDigit != thirdDigit - secondDigit)
            {
                return false;
            }
        }

        return true;
    }
}