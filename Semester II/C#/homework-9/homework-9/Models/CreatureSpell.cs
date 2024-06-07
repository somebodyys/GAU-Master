namespace homework_9.Models;

public class CreatureSpell
{
    public int CreatureID { get; set; }
    public Creature Creature { get; set; }
    public int SpellID { get; set; }
    public Spell Spell { get; set; }
}