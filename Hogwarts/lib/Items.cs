namespace Hogwarts.lib;

public interface IItems
{
    string Name { get; set; }
    string Description { get; set; }
    int PurchasePrice { get; set; }
    int SellPrice { get; set; }
}