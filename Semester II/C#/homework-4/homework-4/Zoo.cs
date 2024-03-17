namespace homework_4;

public class Zoo
{
    private List<Animal> animals;

    public Zoo()
    {
        animals = new List<Animal>();
    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public void PrintAnimals()
    {
        Console.WriteLine("Animals in the zoo:");
        foreach (var animal in animals)
        {
            Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");

            if (animal is Lion lion)
            {
                Console.WriteLine($"Mane Color: {lion.ManeColor}");
            }
            else if (animal is Elephant elephant)
            {
                Console.WriteLine($"Tusk Length: {elephant.TuskLength}");
            }

            Console.WriteLine();
        }
    }
}