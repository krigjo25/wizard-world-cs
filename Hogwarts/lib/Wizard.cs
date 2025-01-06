using System.Collections.Generic;
namespace Hogwarts.lib;

public class Wizard
{
    // Class members
    private int _lvl;
    private int _gold;
    private string _name;
    
    //private House _house = null;
    
    private Wand _wand;
    private Animal _animals = null;
    
    
    // Properties
    public int Gold { get; set; }
    public string Name { get; set; }
    public string Wand { get; set; }
    public string House { get; set; }
    public int Level { get; set; }
    
    private List<Gear> Gears = [];
    public List<Animal> Animals { get; set; }
    public List<Items> Inventory { get; set; }
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
                gear.isEquipped = true;
            }
        }
    }
    public void AddToInventory(Items obj)
    {
        Inventory.Add(obj);
    }
    public void RemoveFromInventory(Items obj)
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
            if (item.isEquipped == true)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(item);
        }
        //Console.WriteLine($"House: {_house}");
        //Console.WriteLine($"BackStory: {_description}");
    }
    
}