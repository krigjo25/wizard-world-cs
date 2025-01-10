

namespace wizardWorld.lib.Spells;

public interface ISpells
{
    public string Type { get; set; }
    public string Effect { get; set; }
}
public class FireSpells : ISpells
{
    private string _type;
    private string _name;
    private string _effect;
    private string _damage;
    private string _description;
    
    public string Type { get; set; }
    public string Name { get; set; }
    public string Effect { get; set; }
    public string Damage { get; set; }
    public string Description { get; set; }

    public FireSpells(string name, string type, string effect, string damage, string description)
    {
        _name = name;
        _type = type;
        _effect = effect;
        _damage = damage;
        _description = description;
    }
    
}
