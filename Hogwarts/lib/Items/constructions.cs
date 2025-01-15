namespace wizardWorld.lib.Items;

internal class GeneralStore : Item
{
    private int _id;
    private int _count;
    private string _itemType;
    private int _purchasePrice;
    private string _description;

    public int ID => _id;
    public int Count
    {
        get => _count;
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("Count cannot be less than 1");
            }
            else if (value - _count < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot remove more items than you have");
            }
            else
            {
                _count = value;
            }

        }
    }

    public int PurchasePrice
    {
        get => _purchasePrice;
    }
    public string ItemType
    {
        get => _itemType;
    }

    

    // List of Items in the store
    public readonly List<Baton> Wands = [];
    public readonly List<Animal> Animals = [];
    
    public GeneralStore(int id, int purchasePrice, string name, string type, string itemType, int rarity = 1, int count = 1, string description = "") : base(name, type, description, rarity)
    {
        _id = id;
        _count = count;
        _itemType = itemType;
        _purchasePrice = purchasePrice;

    }
    
    public void AddItem(Item item)
    {
        switch (item)
        {
            case Animal animal:
                Animals.Add(animal);
                break;
            
            case Baton wand:
                Wands.Add(wand);
                break;
            
        }
    }
    
    private void RemoveItem(Item item)
    {
        switch (item)
        {
            case Animal animal:
                Animals.Remove(animal);
                break;
            
            case Baton wand:
                Wands.Remove(wand);
                break;
            
        }
    }
    
}