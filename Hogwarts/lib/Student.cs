namespace Hogwarts.lib;

public class Student
{
    public string[] Animals { get; set; }
    public string Name { get; set; }
    public string _wand { get; set; }
    public int Gold { get; set; }
    public List<Item> Inventory { get; set; }

    public Student(string name, int gold)
    {
        Gold = gold;
        //Inventory = inventory;
        Name = name;
        Inventory = [];
    }

    public void AddToInventory(Item obj)
    {
        Inventory.Add(obj);
    }
    
}