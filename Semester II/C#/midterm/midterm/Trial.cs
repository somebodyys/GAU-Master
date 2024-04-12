namespace midterm;

public class Trial : Software
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime InstallationDate { get; set; }
    public int TrialDurationMonths { get; set; }

    public override void PrintDetails()
    {
        Console.WriteLine($"Name: {Name}, Brand: {Brand}, Release Date: {ReleaseDate}");
    }

    public override bool IsLicenseValid(DateTime currentDate)
    {
        return InstallationDate.AddMonths(TrialDurationMonths) > currentDate;
    }
}