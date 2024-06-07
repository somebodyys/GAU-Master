using homework_9.Models;
using Microsoft.EntityFrameworkCore;

namespace homework_9.Data;

public class ImaginaryWorldContext : DbContext
{
    public DbSet<Creature> Creatures { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<CreatureLocation> CreatureLocations { get; set; }
    public DbSet<CreatureSpell> CreatureSpells { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ImaginaryWorld;User=sa;Password=1234;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreatureLocation>()
            .HasKey(cl => new { cl.CreatureID, cl.LocationID });

        modelBuilder.Entity<CreatureLocation>()
            .HasOne(cl => cl.Creature)
            .WithMany(c => c.CreatureLocations)
            .HasForeignKey(cl => cl.CreatureID);

        modelBuilder.Entity<CreatureLocation>()
            .HasOne(cl => cl.Location)
            .WithMany(l => l.CreatureLocations)
            .HasForeignKey(cl => cl.LocationID);

        modelBuilder.Entity<CreatureSpell>()
            .HasKey(cs => new { cs.CreatureID, cs.SpellID });

        modelBuilder.Entity<CreatureSpell>()
            .HasOne(cs => cs.Creature)
            .WithMany(c => c.CreatureSpells)
            .HasForeignKey(cs => cs.CreatureID);

        modelBuilder.Entity<CreatureSpell>()
            .HasOne(cs => cs.Spell)
            .WithMany(s => s.CreatureSpells)
            .HasForeignKey(cs => cs.SpellID);
    }
}