namespace homework_3;

public class MyClass_1
{
    private int[] minMax;

    public MyClass_1(int min, int max)
    {
        minMax = new int[2];
        minMax[0] = min;
        minMax[1] = max;
    }

    public void PrintMinMax()
    {
        Console.WriteLine($"Minimum Element: {minMax[0]}");
        Console.WriteLine($"Maximum Element: {minMax[1]}");
    }

}