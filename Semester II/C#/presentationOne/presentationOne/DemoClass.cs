namespace presentationOne;

public class DemoClass : IDisposable
{
    public DemoClass()
    {
        Console.WriteLine("Object created.");
    }

    // Finalizer (destructor)
    ~DemoClass()
    {
        Console.WriteLine("Finalizer called.");
        Dispose(false);
    }
    
    public void Dispose()
    {
        Console.WriteLine("Dispose called.");
        Dispose(true); // Cleanup managed and unmanaged resources
        GC.SuppressFinalize(this); // Suppress finalization as resources are already cleaned up
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Console.WriteLine("Cleaning up managed resources.");
        }
        
        Console.WriteLine("Cleaned up unmanaged resources.");
    }
    
    public static void Run()
    {
        DemoClass obj = new DemoClass();

        obj.Dispose();

        // Force garbage collection
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
    }
}