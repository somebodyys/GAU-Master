namespace midterm;

public class Commercial : Software
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public DateTime InstallationDate { get; set; }
    public int DurationMonths { get; set; }

    public override void PrintDetails()
    {
        Console.WriteLine($"Name: {Name}, Brand: {Brand}, Release Date: {ReleaseDate}, Price: {Price}");
    }

    public override bool IsLicenseValid(DateTime currentDate)
    {
        return InstallationDate.AddMonths(DurationMonths) > currentDate;
    }
}