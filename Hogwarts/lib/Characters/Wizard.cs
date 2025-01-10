// Initialize libraries
using wizardWorld.lib.Items;


namespace wizardWorld.lib.Characters;

internal record Wizard
{
    
    // Class members
    private int _lvl;
    private int _gold;
    private decimal _hp;
    private decimal _ap;
    private string _name;
    
    // List of personal equipment
    private Baton _wand;
    private Animal _pet;
    private object _house;
    
    
    // Properties
    public int Gold { get; set; }

    public string Name
    {
        get => _name;
        set
        {
            if (value != string.Empty && value.Length > 2)
            {
                _name = value;
            }
        }
    }

    public object House
    {
        get => _house;
        set => _house = value;
    }

    public int Level
    {
        get => _lvl; 
        set => _lvl = value;
    }

    public decimal Hp
    {
        get => _hp; 
        set => _hp = value;
    }

    public decimal Ap
    {
        get => _ap;
        set => _ap = value;
    }

    public Baton Wand
    {
        get => _wand;
        set => _wand = value;
    }
    public Animal Pet
    {
        get => _pet;
        set => _pet = value;
        
    }
    public List<Gear> Gears = [];
    
    //  List of Inventorys
    public List<Animal> Animals = [];
    public List<Item> Inventory = [];
    //public List<Spells> Spellbook { get; set; }

    public Wizard(string name, int gold, int lvl = 1, Baton? wand = null, Animal? pet = null, object? house = null)
    {
        _ap = 0;
        _hp = 100;
        _pet = pet;
        _lvl = lvl;
        _name = name;
        _wand = wand;
        _gold = gold;
        _house = house;
        Inventory = [];
        
    }
    
    public void EquipGear(Gear gear)
    {
        foreach (var item in Inventory)
        {
            if (item.Name == gear.Name)
            {
                Console.WriteLine($"Equips the {gear.Name}");
                gear.IsEquipped = true;
                
                Ap += gear.Armour;
            }
        }
    }
    public void DeEquipGear(Gear gear)
    {
        foreach (var item in Inventory.Where(item => item.Name == gear.Name))
        {
            gear.IsEquipped = true;
            if (Ap - gear.Armour >= 0)
            {
                Console.WriteLine($"Wears off the {gear.Name}");
                return;
            }
            Ap -= gear.Armour;
        }
    }
    
    //  Inventory Commands
    public void AddToInventory(Item obj)
    {
        Inventory.Add(obj);
    }
    public void RemoveFromInventory(Item obj)
    {
        Inventory.Remove(obj);
    }
    
    public void PrintInventory()
    {
        foreach (var item in Inventory)
        {
            Console.WriteLine(item);
        }
    }

    public void PrintWizard()
    {
        Console.WriteLine($"Name: {_name},  Level: {_lvl}");
        Console.WriteLine($"Gold: {_gold},  Wand: {_wand}");
        Console.WriteLine($"Pet: {_pet}");
        
        Console.Write("Currently wearing :\n");
        foreach (var item in Gears)
        {
            if (item.IsEquipped == true)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(item);
        }
        
        //Console.WriteLine($"House: {_house}");
        //Console.WriteLine($"BackStory: {_description}");
    }
}