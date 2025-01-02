namespace Hogwarts.lib;

public interface ISpells
{
    public string Type;
    
    public string Effect;
}
public class FireSpells : ISpells
{
    public string Type;
    public string Name;
    
    public string Effect;
    public string Damage;
    public string Description;

    public FireSpells(string type, string name, string effect, string damage, string description)
    {
        Type = type;
        Name = name;
        Effect = effect;
        Damage = damage;
        Description = description;
    }
    
}

{
    // WaterSpells
}

{
}

{
}

{
}
