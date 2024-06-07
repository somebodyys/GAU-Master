namespace homework_9.Models;

public class Creature
{
    public int CreatureID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Habitat { get; set; }
    public int Age { get; set; }
    public string Description { get; set; }
    
    public ICollection<CreatureLocation> CreatureLocations { get; set; }
    public ICollection<CreatureSpell> CreatureSpells { get; set; }
}