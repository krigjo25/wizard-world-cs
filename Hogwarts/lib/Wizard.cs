using System.Collections.Generic;
namespace Hogwarts.lib;

public class Wizard
{
    private int _lvl;
    private int _gold;
    private string _name;
    // private Wand _wand;
    private House _house = null;
    private Animals _animals = null;
    
    public int Gold { get; set; }
    public string Name { get; }
    public int Level { get; set; }
    public object Wand { get; set; }
    
    public House House { get;}
    
    
    
    // public readonly List<Animals> Animals { get; set; }
    public List<Items> Inventory { get; set; }

    

    public Wizard(string name, int gold, Wand wand = null, int lvl = 1)
    {
        _lvl = lvl;
        _name = name;
        _gold = gold;
        _wand = wand;
        Inventory = [];
        _house = SortingHat.SortingHat();
        
    }

    public void AddToInventory(StoreItems obj)
    {
        Inventory.Add(obj);
    }
    
}