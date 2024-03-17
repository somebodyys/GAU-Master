namespace homework_4;

public class Elephant : Animal
{
    public int TuskLength { get; set; }

    public Elephant(string name, int age, int tuskLength) : base(name, age)
    {
        TuskLength = tuskLength;
    }

}