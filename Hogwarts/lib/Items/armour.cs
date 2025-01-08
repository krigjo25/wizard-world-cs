namespace wizardWorld.lib.Items;

public class Gear : Item
{
    private int _rarity;
    private string _name;
    private string _type;
    private bool _isEquipped;
    private decimal _armorBonus;
    private string _description;
    public string Type { get; set; }
    
    
    public int Rarity { get; set; }
    public string Name { get; set; }
    public bool Selected { get; set; }
    public decimal Armour { get; set; }
    public bool IsEquipped { get; set; }
    public string Description { get; set; }
    
    
    public Gear(string name, string type,  int rarity, string description = "", decimal armorBonus = 0) : base(name, type,  description, rarity)
    {
        _name = name;
        _type = type;
        _rarity = rarity;
        _isEquipped = false;
        _armorBonus = armorBonus;
        _description = description;
    }
    
}