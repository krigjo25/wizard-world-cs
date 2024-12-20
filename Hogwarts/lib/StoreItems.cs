namespace Hogwarts.lib;

public class StoreItems(string name, string description, int buyPrice = 0) : IItems
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public int PurchasePrice { get; set; } = buyPrice;
    public int SellPrice { get; set; } = buyPrice /2;
}