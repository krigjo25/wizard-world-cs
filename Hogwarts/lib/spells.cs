namespace Hogwarts.lib;

public interface ISpells
{
    public string Name;
    public string Type;
    
    public string Unlock;
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

public class Spells : ISpells
{
    // WaterSpells
}

public class CoreSpells : ISpells
{
    //  Corespells
}

public class StealthSpells : ISpells
{
    // StealthSpells
}

public class DarkArts : ISpells
{
    // Unforgivable curses
}
