namespace homework_3;

public class Car
{
    private string carColor;
    private int numberOfDoors;

    public string OwnerSurname { get; set; }
    public string Brand { get; set; }

    public Car(string ownerSurname, string brand, string carColor, int numberOfDoors)
    {
        this.OwnerSurname = ownerSurname;
        this.Brand = brand;
        this.carColor = carColor;
        this.numberOfDoors = numberOfDoors;
    }

    public void PrintPrivateProperties()
    {
        Console.WriteLine($"Car Color: {carColor}");
        Console.WriteLine($"Number of Doors: {numberOfDoors}");
    }
}