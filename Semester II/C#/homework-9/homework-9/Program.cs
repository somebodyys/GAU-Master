// dotnet ef migrations add InitialCreate
// dotnet ef database update

// dotnet ef dbcontext scaffold "Server=localhost,1433;Database=ImaginaryWorld;User=sa;Password=1234;" Microsoft.EntityFrameworkCore.SqlServer -o Models


using homework_9.Data;
using homework_9.Models;

static void Main(string[] args)
{
    using (var context = new ImaginaryWorldContext())
    {
        context.Database.EnsureCreated();

        var creature = new Creature
        {
            Name = "Phoenix",
            Type = "Fire",
            Habitat = "Volcano",
            Age = 1000,
            Description = "A mythical bird that regenerates from ashes."
        };

        context.Creatures.Add(creature);
        context.SaveChanges();

        var creatures = context.Creatures.ToList();
        Console.WriteLine("Creatures in the database:");
        foreach (var c in creatures)
        {
            Console.WriteLine($"{c.CreatureID}: {c.Name} - {c.Type} ({c.Habitat})");
        }

        var firstCreature = creatures.FirstOrDefault();
        if (firstCreature != null)
        {
            firstCreature.Age += 100;
            context.SaveChanges();
        }

        if (firstCreature != null)
        {
            context.Creatures.Remove(firstCreature);
            context.SaveChanges();
        }
    }
}