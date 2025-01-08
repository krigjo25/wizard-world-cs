namespace wizardWorld.lib.Items;

public interface IItems
{
    
    public string Name { get; set; }
    public string Type { get; set; }
    public int Rarity { get; set; }
    //public string Description { get; set; }

}

public class Item : IItems
{
    private int _count;
    private int _rarity;
    private string _name;
    private string _type;
    private string _description;


    public int Rarity
    {
        get => _rarity;
        set => _rarity = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Type
    {
        get => _type;
        set => _type = value;
    }

    

    public Item(string name, string type, string description = "", int rarity = 0)
    {
        Name = name;
        _type = type;
        _rarity = rarity;
        _description = description;
    }
    
}

