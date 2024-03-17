namespace homework_4;

public class Triangle : Shape
{
    public double TriangleBase { get; set; }
    public double Height { get; set; }

    public Triangle(double triangleBase, double height)
    {
        TriangleBase = triangleBase;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * TriangleBase * Height;
    }
}