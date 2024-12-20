namespace Hogwarts.lib;

public class StoreItems: Items
{
    public StoreItems(string name, string type,  int purchasePrice = 0): base(name, type, purchasePrice)
    {

        //  Set an random description based on its name and type
        SetDescription(Name, Type);
    }

    private void SetDescription(string name, string type)
    {
        
        Description = "";
    }
}