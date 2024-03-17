namespace homework_4;

public class Salad : Food
{
    private string dressing;

    public Salad(string name, double price, string dressing) : base(name, price)
    {
        this.dressing = dressing;
    }

    public override void Cook()
    {
        Console.WriteLine($"Preparing {Name} salad with {dressing} dressing.");
        Console.WriteLine("Mix the ingredients thoroughly.");
        Console.WriteLine("Chill the salad before serving.");
    }
}