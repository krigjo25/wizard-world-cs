using System.Collections;
using System.Collections.Generic;
namespace Hogwarts.lib;

internal class Wizard : IEnumerable
{
    // Class members
    private int _lvl;
    private int _gold;
    private decimal _hp;
    private string _name;
    private decimal _armour;
    
    //private House _house = null;
    
    private Wand _wand;
    private Animal _animals = null;
    
    
    // Properties
    public int Gold { get; set; }
    public string Name { get; set; }
    public string Wand { get; set; }
    public string House { get; set; }
    public int Level { get; set; }
    public decimal HP { get; set; }
    public decimal Armour { get; set; }
    
    private List<Gear> Gears = [];
    public List<Animal> Animals { get; set; }
    public List<Item> Inventory { get; set; }
    //public List<Spells> Spellbook { get; set; }

    public Wizard(string name, int gold, Wand wand = null, int lvl = 1)
    {
        _lvl = lvl;
        _armour = 0;
        _name = name;
        _wand = wand;
        _gold = gold;
        Inventory = [];
        //_house = School.SortingHat();
    }
    
    public void EquipGear(Gear gear)
    {
        foreach (var item in Inventory)
        {
            if (item.Name == gear.Name)
            {
                Console.WriteLine($"Equips the {gear.Name}");
                gear.IsEquipped = true;
                
                Armour += gear.Armour;
            }
        }
    }
    public void DeEquipGear(Gear gear)
    {
        foreach (var item in Inventory.Where(item => item.Name == gear.Name))
        {
            gear.IsEquipped = true;
            if (Armour - gear.Armour >= 0)
            {
                Console.WriteLine($"Wears off the {gear.Name}");
                return;
            }
            Armour -= gear.Armour;
        }
    }
    
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
        Console.WriteLine($"Name: {_name}, Level: {_lvl}");
        Console.WriteLine($"Gold: {_gold}");
        Console.WriteLine($"Wand: {_wand}");
        Console.WriteLine($"Level: {_lvl}");
        Console.WriteLine($"Animals: {_animals}");
        
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