namespace Hogwarts.lib;

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

public class Wand : Item
    {
        public Wand(string name, string type,  int rarity = 0, string description = "") :
            base(name, type, description, rarity)
        {
        }
        
    }

internal class GeneralStore : Item
{
    private int _count;
    private int _purchasePrice;
    private string _description;

    public int Count
    {
        get => _count;
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("Count cannot be less than 1");
            }
            else if (value - _count < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot remove more items than you have");
            }
            else
            {
                _count = value;
            }

        }
    }

    public int PurchasePrice
    {
        get => _purchasePrice;
    }
    
    
    // List of Items in the store
    public readonly List<Wand> Wands = [];
    public readonly List<Animal> Animals = [];
    
    public GeneralStore(int purchasePrice, string name, string type, int rarity = 1, int count = 1, string description = "") : base(name, type, description, rarity)
    {
        _count = count;
        _purchasePrice = purchasePrice;
    }
    
    public void AddItem(Item item)
    {
        switch (item)
        {
            case Animal animal:
                Animals.Add(animal);
                break;
            
            case Wand wand:
                Wands.Add(wand);
                break;
            
        }
    }
    
    private void RemoveItem(Item item)
    {
        switch (item)
        {
            case Animal animal:
                Animals.Remove(animal);
                break;
            
            case Wand wand:
                Wands.Remove(wand);
                break;
            
        }
    }
}

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