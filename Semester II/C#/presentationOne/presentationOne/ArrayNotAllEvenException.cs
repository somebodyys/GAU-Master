namespace presentationOne;

public class ArrayNotAllEvenException : Exception
{
    public ArrayNotAllEvenException() : base("Array does not contain all even numbers.")
    {
    }
}