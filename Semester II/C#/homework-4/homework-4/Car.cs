namespace homework_4;

public class Car
{
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int CurrentSpeed { get; private set; }
    
    public Car(string model, int year, string color)
    {
        Model = model;
        Year = year;
        Color = color;
        CurrentSpeed = 0;
    }
    
    public void Accelerate(int increment)
    {
        if (increment < 0)
        {
            throw new ArgumentException("Increment value must be positive.");
        }
        CurrentSpeed += increment;
        Console.WriteLine($"Speed increased by {increment}. Current speed: {CurrentSpeed}");
    }
    
    public void Brake(int decrement)
    {
        if (decrement < 0)
        {
            throw new ArgumentException("Decrement value must be positive.");
        }
        if (CurrentSpeed - decrement < 0)
        {
            throw new InvalidOperationException("Speed cannot be negative.");
        }
        CurrentSpeed -= decrement;
        Console.WriteLine($"Speed decreased by {decrement}. Current speed: {CurrentSpeed}");
    }
}