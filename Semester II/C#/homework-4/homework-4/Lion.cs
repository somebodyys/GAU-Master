namespace homework_4;

public class Lion : Animal
{
    public string ManeColor { get; set; }

    public Lion(string name, int age, string maneColor) : base(name, age)
    {
        ManeColor = maneColor;
    }
}