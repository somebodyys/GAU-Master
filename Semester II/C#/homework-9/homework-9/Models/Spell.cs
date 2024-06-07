namespace homework_9.Models;

public class Spell
{
    public int SpellID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PowerLevel { get; set; }
    
    public ICollection<CreatureSpell> CreatureSpells { get; set; }
}