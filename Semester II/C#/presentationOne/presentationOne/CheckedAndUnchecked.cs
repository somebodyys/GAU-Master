namespace presentationOne;

public class CheckedAndUnchecked
{
    public static void Run()
    {
        int a = int.MaxValue;
        int b = 2;
        
        checked
        {
            try
            {
                int result = a * b;
                Console.WriteLine("Result (checked): " + result);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error (checked): " + ex.Message);
            }
        }
        
        unchecked
        {
            int result = a * b;
            Console.WriteLine("Result (unchecked): " + result);
        }

        Console.WriteLine("Program continues after checked and unchecked blocks.");
    }
}