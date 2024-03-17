namespace homework_4;

public abstract class Food
{
    protected string name;
    protected double price;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public Food(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public abstract void Cook();
}