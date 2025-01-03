namespace Hogwarts.lib;

public class Canvas : Items
{
    protected Canvas(string name, string type, string description, int purchasePrice = 0, bool sellAble = false) : base(name, type, description, purchasePrice, sellAble)
    {
    }
}

public class TheFatLady : Canvas
{
    private string _name;
    private string _password;
    
    public string Name { get; set; }
    public string Password { get; set; }

    protected TheFatLady(string name = "The Fat Lady", string type = "Painting", string description = "An Enchanted painting that guards the common room for Griffindor", int purchasePrice = 0, bool sellAble = false) : base(name, type, description, purchasePrice, sellAble)
    {
        _name = name;
        Password = "password";
    }
}