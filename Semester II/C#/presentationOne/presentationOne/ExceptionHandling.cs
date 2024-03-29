namespace presentationOne;

public class ExceptionHandling
{
    public static void Run()
    {
        try
        {
            int[] numbers = { 1, 2, 3 };
            int index = 5;
            int value = numbers[index];
            Console.WriteLine("Value: " + value);
            
            int[] numbersList = { 2, 4, 6, 7, 8 }; 
            
            foreach (int num in numbersList)
            {
                if (num % 2 != 0)
                {
                    throw new ArrayNotAllEvenException();
                }
            }
        }
        catch (ArrayNotAllEvenException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: Invalid operation exception occurred.");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: Index is out of range.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Attempted to divide by zero.");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Error: Argument is null.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: Argument exception occurred.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Format exception occurred.");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error: Overflow exception occurred.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Finally block executed.");
        }

        Console.WriteLine("Program continues after try-catch-finally block.");
    }
}