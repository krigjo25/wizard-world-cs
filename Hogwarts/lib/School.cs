namespace Hogwarts.lib;

internal class School
{
    internal readonly List<House> houses = [];

    private void InitalizeHouses()
    {
        houses.Add(new House());
    }
}

internal class House : School
{
    // Class members
    private int _points = 0;
    private string _name;

    private string _head;

    private string entrancename;

    private string entrancePassword;
    // Properties
    
    public string Name { get => _name; set => _name = value; }
    public House(string name, string head, string entrancename, string entrancePassword = null)
    {
        
    }
}