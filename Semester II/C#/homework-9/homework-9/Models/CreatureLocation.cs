namespace homework_9.Models;

public class CreatureLocation
{
    public int CreatureID { get; set; }
    public Creature Creature { get; set; }
    public int LocationID { get; set; }
    public Location Location { get; set; }
}