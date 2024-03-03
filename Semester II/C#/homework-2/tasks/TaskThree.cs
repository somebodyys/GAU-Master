namespace tasks;

public class TaskThree
{
    public static void Run()
    {
        double weight, height;

        Console.Write("Enter your weight (in kilograms): ");
        if (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
        {
            Console.WriteLine("Invalid input for weight. Please enter a positive number.");
            return;
        }

        Console.Write("Enter your height (in meters): ");
        if (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            Console.WriteLine("Invalid input for height. Please enter a positive number.");
            return;
        }

        var bmi = CalculateBmi(weight, height);

        switch (bmi)
        {
            case var _ when bmi < 16:
                Console.WriteLine("Danger zone! Very severely underweight.");
                break;
            case var _ when bmi >= 16 && bmi < 18.5:
                Console.WriteLine("Deficit weight. Underweight.");
                break;
            case var _ when bmi >= 18.5 && bmi < 25:
                Console.WriteLine("Normal weight.");
                break;
            case var _ when bmi >= 25 && bmi < 30:
                Console.WriteLine("Excess weight. Overweight.");
                break;
            case var _ when bmi >= 30:
                Console.WriteLine("Fat! Obese.");
                break;
            default:
                Console.WriteLine("Invalid BMI value.");
                break;
        }
    }
    
    private static double CalculateBmi(double weight, double height)
    {
        return weight / (height * height);
    }
}