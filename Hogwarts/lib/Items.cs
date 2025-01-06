namespace Hogwarts.lib;

public interface IItems
{
    
    public string Name { get; set; }
    public string Type { get; set; }
    public int Rarity { get; set; }
    public string Description { get; set; }
}

public class Items : IItems
{
    private int _rarity;
    private string _name;
    private string _type;
    private string _description;

    public int Rarity { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public int PurchasePrice { get; set; }
    public string Description { get; set; }

    protected Items(string name, string type, string description = "", int rarity = 0)
    {
        _name = name;
        _type = type;
        _description = description;
        _rarity = rarity;
    }
}

public class Animal : Items
    {
        private string race = "";
        
        public Animal(string name, string type, string description, string race, int rarity = 0) :
            base(name, type, description, rarity)
        {

        }
        
        public virtual void SendMessage()
        {
        }
        public virtual void SendSound()
        {
        }
        public virtual void Transport(Wizard student)
        {
        }
    }

public class Wand : Items
    {
        public Wand(string name, string type, string description, int rarity = 0) :
            base(name, type, description, rarity)
        {
        }
        
    }

public class StoreItems : Items
{
    private int _rarity;
    private string _name;
    private string _type;
    private int _purchasePrice;
    private string _description;


    public StoreItems( string name, string type, int purchasePrice, string description = "", int rarity = 0) : base(name, type, description, rarity)
    {
        _rarity = rarity;
        _name = name;
        _type = type;
        _description = description;
        _purchasePrice = purchasePrice;
        
    }

    public int Rarity { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int PurchasePrice { get; set; }
    public string Description { get; set; }
}

public class Gear : Items
{
    private string _name;
    private string _type;
    private int _rarity;
    private bool _isEquipped;
    private decimal _armorBonus;
    private string _description;
    public string Type { get; set; }
    
    
    public int Rarity { get; set; }
    public string Name { get; set; }
    public bool Selected { get; set; }
    public decimal ArmorBonus { get; set; }
    private bool IsEquipped { get; set; }
    public string Description { get; set; }
    
    
    public Gear(string name, string type,  int rarity, string description = "", int armorBonus = 0) : base(name, type,  description, rarity)
    {
        _name = name;
        _type = type;
        _rarity = rarity;
        _isEquipped = false;
        _armorBonus = armorBonus;
        _description = description;
    }
    
}