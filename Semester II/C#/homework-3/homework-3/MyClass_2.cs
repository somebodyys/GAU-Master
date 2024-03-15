namespace homework_3;

public class MyClass_2
{
    public MyClass_1 FindMinMax(int[] myArray)
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        foreach (int num in myArray)
        {
            if (num < min)
                min = num;
            if (num > max)
                max = num;
        }

        return new MyClass_1(min, max);
    }
}