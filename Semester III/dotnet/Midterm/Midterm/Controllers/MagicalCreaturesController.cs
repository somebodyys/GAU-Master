using Microsoft.AspNetCore.Mvc;
using Midterm.Filters;
using Midterm.Models;

namespace Midterm.Controllers;
    
[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(BasicAuthorizationFilter))]
public class MagicalCreaturesController : ControllerBase
{
    private static readonly List<MagicalCreature> Creatures = [
        new MagicalCreature(
            "Flare",
            "Phoenix",
            MagicAffinityType.Fire,
            500,
            100,
            85,
            ["Fire Breath", "Rebirth"],
            50,
            true,
            "Elder Flame Valley",
            ["Water", "Cold"],
            9,
            90
        ),
        new MagicalCreature(
            "Aqua",
            "Water Serpent",
            MagicAffinityType.Water,
            300,
            120,
            70,
            ["Water Jet", "Tidal Wave"],
            60,
            false,
            "Ocean's Deep",
            ["Fire", "Electricity"],
            7,
            80
        ),
        new MagicalCreature(
            "Terra",
            "Earth Gollum",
            MagicAffinityType.Earth,
            1000,
            200,
            100,
            ["Earthquake", "Rock Shield"],
            30,
            false,
            "Mountain Core",
            ["Air", "Magic"],
            5,
            50
        )
    ];
    
    [HttpGet]
    public ActionResult<IEnumerable<MagicalCreature>> Get()
    {
        return Ok(Creatures);
    }
    
    [HttpGet("{id:guid}")]
    public ActionResult<MagicalCreature> Get(Guid id)
    {
        var creature = Creatures.FirstOrDefault(c => c.Id == id);
        if (creature == null) return NotFound();
        
        return Ok(creature);
    }
    
    [HttpPost]
    public ActionResult<MagicalCreature> Post([FromBody] MagicalCreature newCreature)
    {
        Creatures.Add(newCreature);
        
        return CreatedAtAction(nameof(Get), new { id = newCreature.Id }, newCreature);
    }
    
    [HttpPut("{id:guid}")]
    public ActionResult Update(Guid id, [FromBody] MagicalCreature updatedCreature)
    {
        var creature = Creatures.FirstOrDefault(c => c.Id == id);
        if (creature == null) return NotFound();

        creature.Name = updatedCreature.Name;
        creature.Species = updatedCreature.Species;
        creature.MagicAffinity = updatedCreature.MagicAffinity;
        creature.Age = updatedCreature.Age;
        creature.Health = updatedCreature.Health;
        creature.PowerLevel = updatedCreature.PowerLevel;
        creature.Abilities = updatedCreature.Abilities;
        creature.Mana = updatedCreature.Mana;
        creature.IsLegendary = updatedCreature.IsLegendary;
        creature.RegionOrigin = updatedCreature.RegionOrigin;
        creature.Weaknesses = updatedCreature.Weaknesses;
        creature.FriendlinessLevel = updatedCreature.FriendlinessLevel;
        creature.Intelligence = updatedCreature.Intelligence;

        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var creature = Creatures.FirstOrDefault(c => c.Id == id);
        if (creature == null) return NotFound();

        Creatures.Remove(creature);
        return NoContent();
    }
    
    [HttpGet("legendary")]
    public ActionResult<IEnumerable<MagicalCreature>> GetLegendaryCreatures()
    {
        var legendaryCreatures = Creatures.Where(c => c.IsLegendary).ToList();
        if (legendaryCreatures.Count == 0) return NotFound("No legendary creatures found.");
        
        return Ok(legendaryCreatures);
    }
}
