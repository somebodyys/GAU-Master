namespace midterm;

public class TaskOne
{
    public static void Run()
    {
        int n = 5;
        Software[] softwareArray = new Software[n];
        
        softwareArray[0] = new Free { Name = "Free Software 1", Brand = "Brand A", ReleaseDate = DateTime.Now };
        softwareArray[1] = new Trial { Name = "Trial Software 1", Brand = "Brand B", ReleaseDate = DateTime.Now, InstallationDate = DateTime.Now, TrialDurationMonths = 3 };
        softwareArray[2] = new Commercial { Name = "Commercial Software 1", Brand = "Brand C", ReleaseDate = DateTime.Now, Price = 99.99m, InstallationDate = DateTime.Now, DurationMonths = 12 };
        softwareArray[3] = new Free { Name = "Free Software 2", Brand = "Brand D", ReleaseDate = DateTime.Now };
        softwareArray[4] = new Commercial { Name = "Commercial Software 2", Brand = "Brand E", ReleaseDate = DateTime.Now, Price = 149.99m, InstallationDate = DateTime.Now, DurationMonths = 6 };
        
        Console.WriteLine("Enter the current date (yyyy-mm-dd): ");
        DateTime currentDate = DateTime.Parse(Console.ReadLine());
        
        foreach (Software software in softwareArray)
        {
            if (software.IsLicenseValid(currentDate))
            {
                software.PrintDetails();
                Console.WriteLine($"License Valid: {software.IsLicenseValid(currentDate)}");
                Console.WriteLine();
            }
        }
    }
}