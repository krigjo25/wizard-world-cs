using System.Collections.Generic;
namespace Hogwarts.lib;

public class Student
{
    private int _lvl;
    private int _gold;
    private string _name;
    private string _wand;
    private string _house;
    
    public int Gold { get; set; }
    public string Name { get; set; }
    public string Wand { get; set; }
    public string House { get; set; }
    public int Level { get; set; }
    
    
    // public readonly List<Animals> Animals { get; set; }
    public List<Items> Inventory { get; set; }

    

    public Student(string name, int gold, string wand = "None", int lvl = 1)
    {
        _lvl = lvl;
        _name = name;
        _gold = gold;
        _wand = wand;
        Inventory = [];
        //_house = School.SortingHat();
        
       
    }

    public void AddToInventory(StoreItems obj)
    {
        Inventory.Add(obj);
    }
    
}