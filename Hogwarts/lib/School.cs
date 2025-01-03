namespace Hogwarts.lib;

public class School
{
    protected readonly List<House> houses = [];

    public void InitializeHouse()
    {
        houses.Add(new House("Slytherin", "Severus Snape.", typeof(HiddenWall)));
        houses.Add(new House("Hufflepuff", "Pomona Sprout", typeof(Barrel_Stable)));
        houses.Add(new House("Griffindoor", "Minerva McGonagall", typeof(TheFatLady)));
        houses.Add(new House("Raven Claw", "Filius Flitwick.",typeof(Bronze_Eagle_Statue)));
    }
    
    
}

public class House : School
{
    private int _points = 0;
    private string _name = string.Empty;
    private string _head = string.Empty;
    private object _entrance = new object();

    // Properties
    public int Points { get; set; }

    public string Name
    {
        get => _name; 
        set => _name = value;
    }
    public string Head { get => _head; set => _head = value; }
    public object Entrance { get => _entrance; set => _entrance = value; }
    
    public House(string name, string head, object entrance)
    {
        Name = name;
        Head = head;
        Entrance = entrance;
    }
}

public class SortingHat: School
{

    public static House SortingHat()
    {
        throw new NotImplementedException();
    }
}