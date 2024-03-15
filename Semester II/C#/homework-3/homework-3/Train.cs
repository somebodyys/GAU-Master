namespace homework_3;

public class Train
{
    private int numberOfSections;
    private int[] passengersInSection;
    private decimal ticketPrice;
    private int soldTickets;
    
    public Train()
    {
        numberOfSections = 0;
        passengersInSection = null;
        ticketPrice = 0.0m;
        soldTickets = 0;
    }
    
    public void SetValues(int numberOfSections, int[] passengersInSection, decimal ticketPrice, int soldTickets)
    {
        this.numberOfSections = numberOfSections;
        this.passengersInSection = passengersInSection;
        this.ticketPrice = ticketPrice;
        this.soldTickets = soldTickets;
    }
    
    public void PrintProperties()
    {
        Console.WriteLine($"Number of Sections: {numberOfSections}");
        Console.Write("Number of Passengers in Each Section: ");
        foreach (int passengers in passengersInSection)
        {
            Console.Write(passengers + " ");
        }
        Console.WriteLine();
        Console.WriteLine($"Ticket Price: {ticketPrice:C}");
        Console.WriteLine($"Number of Sold Tickets: {soldTickets}");
    }
    
    public decimal CalculateTotalIncome()
    {
        return ticketPrice * soldTickets;
    }
}