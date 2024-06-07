namespace homework_9.Models;

public class Location
{
    public int LocationID { get; set; }
    public string Name { get; set; }
    public string TerrainType { get; set; }
    public string Climate { get; set; }
    public string Description { get; set; }
    
    public ICollection<CreatureLocation> CreatureLocations { get; set; }
}