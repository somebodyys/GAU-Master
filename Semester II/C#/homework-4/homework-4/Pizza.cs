namespace homework_4;

public class Pizza : Food
{
    private string[] toppings;

    public Pizza(string name, double price, string[] toppings) : base(name, price)
    {
        this.toppings = toppings;
    }

    public override void Cook()
    {
        Console.WriteLine($"Preparing {Name} pizza with toppings: {string.Join(", ", toppings)}");
        Console.WriteLine("Bake the pizza in the oven.");
        Console.WriteLine("Serve hot!");
    }
}