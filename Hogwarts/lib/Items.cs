namespace Hogwarts.lib;

public interface IItems
{
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Selected { get; set; }
    public bool Sellable { get; set; }
    public int SellPrice { get; set; }
    public int PurchasePrice { get; set; }
    public string Description { get; set; }
}

public class Items : IItems
{
    public string Name { get; set; }
    public string Type { get; set; }
    
    public bool Selected { get; set; }
    public bool Sellable { get; set; }
    public int SellPrice { get; set; }
    public int PurchasePrice { get; set; }
    public string Description { get; set; }
    
    protected Items(string name, string type, int purchasePrice, bool sellAble = true)
    {
        Name = name;
        Type = type;
        //Description = description;
        if (Sellable)
        {
            SellPrice = PurchasePrice / 2;
        }
        PurchasePrice = purchasePrice;
        
    }
}


public class Animals : Items
{
    protected Animals(string name, string type, string description, int purchasePrice, bool sellAble = true) : base(name, type, purchasePrice, sellAble)
    {
        
    }
}