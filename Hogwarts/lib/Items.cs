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
    private int _count;
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

internal class Animal : Items
    {
        //private string Race { get; set; }
        
        public Animal(string name, string type, int rarity = 0, string description = "") :
            base(name, type, description, rarity)
        {

        }
        
        public virtual void SendMessage()
        {
            if (Name == "Owl")
            {
                // Send Message
            }

        }
        public virtual void SendSound()
        {
            if (Name == "Owl")
            {
                Console.WriteLine("Hoot Hoot");
            }
            else if (Name == "Rat")
            {
                Console.WriteLine("Squeak Squeak");
            }
            else if (Name == "Cat")
            {
                Console.WriteLine("Meow Meow");
            }
            else if (Name == "Toad")
            {
                Console.WriteLine("Croak Croak");
            }
        }
        public virtual void Transport(Wizard student)
        {
            // Transport the student
        }
    }

internal class Wand : Items
    {
        public Wand(string name, string type,  int rarity = 0, string description = "") :
            base(name, type, description, rarity)
        {
        }
        
    }

internal class GeneralStore : Items
{
    private int _count;
    private int _rarity;
    private string _name;
    private string _type;
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

    public int Rarity { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } 
    public int PurchasePrice { get; set; }
    public string Description { get; set; }
    
    
    // List of Items in the store
    public readonly List<Wand> Wands = [];
    public readonly List<Animal> Animals = [];
    
    public GeneralStore(int purchasePrice, string name, string type, int rarity = 1, int count = 1, string description = "") : base(name, type, description, rarity)
    {
        _count = count;
        _rarity = rarity;
        _name = name;
        _type = type;
        _purchasePrice = purchasePrice;
        _description = description;
    }
    
    public void AddItem(Items item)
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
    
    private void RemoveItem(Items item)
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

public class Gear : Items
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