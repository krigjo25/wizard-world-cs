namespace Hogwarts.lib;

public class Student
{
    public string[] Animals { get; set; }
    public string Name { get; set; }
    public string _wand { get; set; }
    public int Gold { get; set; }
    public List<Item> Inventory { get; set; }

    public Student(string[] arg, string name, string wand, int gold)
    {
        Gold = gold;
        Inventory = inventory;
        Name = name;
        _wand = wand;
        Animals = arg;
    }

    public void AddToInventory(Item obj )
    {
        Inventory.Add(obj);
    }
    
}

public class Item
{
    public string Name { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }

    public Item(string name,string description, string message = "")
    {
        Name = name;
        Message = message;
        Description = description;
    }

    public void SendMessage(string message, Student student)
    {
        
        // Send Message
    }

    public void HealStudent(Student student, int hp)
    {
        
    }
    
    
}