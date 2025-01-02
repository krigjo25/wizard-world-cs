namespace Hogwarts.lib;

internal class School
{
    internal readonly List<House> houses = [];

    private void InitalizeHouses()
    {
        houses.Add(new House("Slytherin", "Severus Snape.", HiddenWall));
        houses.Add(new House("Hufflepuff", "Pomona Sprout", Barrel_Stable));
        houses.Add(new House("Griffindoor", "Minerva McGonagall", The_Fat_Lay));
        houses.Add(new House("Raven Claw", "Filius Flitwick.". Bronze_Eagle_Statue));
    }
}

internal class House : School
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