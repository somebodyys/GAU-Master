using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        task1();
        Console.WriteLine(task2());
        task3();
        Console.WriteLine(task4());
    }
    
    public static void task1()
    {
        Console.Write("x = ");
        string inputX = Console.ReadLine();
        
        Console.Write("y = ");
        string inputY = Console.ReadLine();
        
        if (int.TryParse(inputX, out int x) && int.TryParse(inputY, out int y))
        {
            int z;
            int absoluteDifference = Math.Abs(x - y);
            
            if(absoluteDifference == 4){
                z = 2*x + 3*y;
            } else if (absoluteDifference == 5){
                z = (int)Math.Sqrt(x + y);
            } else if (absoluteDifference == 6) {
                z = y - x;
            } else {
                z = 10;
            }
            
            Console.WriteLine($"z = {z}");
        }
        else
        {
            Console.WriteLine("Error!");
        }
    }
    
    public static bool task2(){
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
    
        return (a + b > c) && (a + c > b) && (b + c > a);
    }
    
    public static void task3(){
        Console.Write("x = ");
        double x = double.Parse(Console.ReadLine());
        
        Console.WriteLine($"S = {x * x}");
        Console.WriteLine($"P = {4 * x}");
    }
    
    public static bool task4(){
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());
        
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}