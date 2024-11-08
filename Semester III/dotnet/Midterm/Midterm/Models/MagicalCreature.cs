using System.Runtime.Serialization;

namespace Midterm.Models;

[DataContract]
public class MagicalCreature
{
    [DataMember]
    public Guid Id { get; set; }
    
    [DataMember]
    public string Name { get; set; }
    
    [DataMember]
    public string Species { get; set; }
    
    [DataMember]
    public MagicAffinityType MagicAffinity { get; set; }
    
    [DataMember]
    public int Age { get; set; }
    
    [DataMember]
    public int Health { get; set; }
    
    [DataMember]
    public int PowerLevel { get; set; }
    
    [DataMember]
    public List<string> Abilities { get; set; }
    
    [DataMember]
    public int Mana { get; set; }
    
    [DataMember]
    public bool IsLegendary { get; set; }
    
    [DataMember]
    public string RegionOrigin { get; set; }
    
    [DataMember]
    public List<string> Weaknesses { get; set; }
    
    [DataMember]
    public int FriendlinessLevel { get; set; }
    
    [DataMember]
    public int Intelligence { get; set; }
    
    public MagicalCreature(
        string name,
        string species,
        MagicAffinityType magicAffinity,
        int age,
        int health,
        int powerLevel,
        List<string> abilities,
        int mana,
        bool isLegendary,
        string regionOrigin,
        List<string> weaknesses,
        int friendlinessLevel,
        int intelligence
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Species = species;
        MagicAffinity = magicAffinity;
        Age = age;
        Health = health;
        PowerLevel = powerLevel;
        Abilities = abilities;
        Mana = mana;
        IsLegendary = isLegendary;
        RegionOrigin = regionOrigin;
        Weaknesses = weaknesses;
        FriendlinessLevel = friendlinessLevel;
        Intelligence = intelligence;
    }

    public void CastSpell(string spell)
    {
        if (Mana >= 10)
        {
            Mana -= 10;
            Console.WriteLine($"{Name} casts {spell}!");
        }
        else
        {
            Console.WriteLine($"{Name} has insufficient Mana to cast {spell}.");
        }
    }

    public void Regenerate(int amount)
    {
        Health += amount;
        
        Console.WriteLine($"{Name} regenerates, increasing Health by {amount}.");
    }

    public void AddAbility(string ability)
    {
        Abilities.Add(ability);
        
        Console.WriteLine($"{Name} learns a new ability: {ability}.");
    }

    public string BattleCry()
    {
        return $"{Name} lets out a mighty roar! Power Level: {PowerLevel}";
    }

    public void LevelUp()
    {
        PowerLevel += 10;
        Health += 20;
        Mana -= 5;
        
        Console.WriteLine($"{Name} levels up! Power Level: {PowerLevel}, Health: {Health}, Mana: {Mana}");
    }

    public string RevealWeakness()
    {
        if (Weaknesses.Count == 0) return "No weaknesses!";
        
        var random = new Random();
        int index = random.Next(Weaknesses.Count);
        return Weaknesses[index];
    }

    public string GetFriendlyGreeting()
    {
        return FriendlinessLevel > 5 ? $"{Name} greets you warmly!" : $"{Name} seems hesitant to greet you.";
    }
}

public enum MagicAffinityType
{
    Fire,
    Water,
    Earth,
    Air,
    Shadow,
    Light
}