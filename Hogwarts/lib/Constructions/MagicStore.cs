//  Libraries used for the program 
using wizardWorld.lib.Items;
using wizardWorld.lib.Characters;
using wizardWorld.lib.TextWeaver;

namespace wizardWorld.lib.Constructions;

public class Store
{
    string[] wands = ["unicorn wand", "troll wand", "phoenix wand"];

    private readonly Konsole _konsole = new Konsole();
    private readonly Wizard wizard;
    
    // List of items in the store
    private List<Baton> Wands = [];
    private List<Animal> Animals = [];
    internal List<GeneralStore> StoreProduct = [];
    internal List<GeneralStore> ShoppingCart { get; } = [];

    public Store(Wizard wizard)
    {
        InitializeProducts();
        Console.WriteLine("Initialized!");
        this.wizard = wizard;
    }
    private bool CalculateRate()
    {
        //  Randomize a boolean value
        bool caught = false;
        
        //  Fetch percentage of decrement 
        var decrease = (decimal)(10.1 * ShoppingCart.Count / 100.0);
        
        //  Randomize a number based on the percentage
        
        //  Initializing an array of strings
        string [] array = [
            $"As suspicious as {wizard.Name} are, {wizard.Name} turn his face towards the sales representive\n The sales representive didn't face {wizard.Name}. and wish him a beautiful day further.",
            $"As suspicious {wizard.Name} are, {wizard.Name} turn his face towards the sales representive\n The sales representive did face {wizard.Name} and wish him a beautiful day further.",
            $"As {wizard.Name} were about to exit the store, the store owner notices his suspicious behavior",
            $"As {wizard.Name} were about to exit the store, the store owner notices a suspicious Clump in his sweater",
        ];
        
        // Randomize a number
        int n = new Random().Next(0, array.Length);

        var text = array[n];

        Random random = new Random();
        
        if (caught)
        {
            return false;
        }
        return true;
    }
    private int CalculatePrice(int rarity, string type)
    {
        switch (type)
        {
            case "Animal":
                return rarity * 100;

            case "Wand":
                return rarity * 200;
        }

        return 0;
    }
    
    private void InitializeProducts()
    {
        //  Initializing animals
        Animals.Add(new Animal("Owl", 1, "Aerial"));
        Animals.Add(new Animal("Cat",  1));
        Animals.Add(new Animal("Rat", 1));
        Animals.Add(new Animal("Toad", 1));
        
        foreach (var wand in wands)
        {
            if (wand == "Unicorn wand")
            {
                Wands.Add(new Baton(wand, "Light", 1));
            }
            else
            {
                Wands.Add(new Baton(wand, "Dark", 1));
            }
        }

        //  Initializing a counter
        var index = 1;
        
        //  Available animals in the store
        for (var i = 0; i < Animals.Count; i++)
        {
            var element = Animals[i];
            StoreProduct.Add(new GeneralStore(index, CalculatePrice(element.Rarity, "Animal"), element.Organism, element.Type,
                "Animal", element.Rarity));
            ++index;
        }
        
        //  Available wands in the store
        foreach (var element in Wands)
        {
            StoreProduct.Add(new GeneralStore(index, CalculatePrice(element.Rarity, "Wand"), element.Name, element.Type, "Wand", element.Rarity));
            ++index;
        }
        
        // Available misc items in the store
    }

    private void SellItem()
    {
        _konsole.CleanConsole();
        
        int n = 0;
        
        // Calculate the price for the items
        foreach (var element in ShoppingCart)
        {
            n += element.PurchasePrice;
        }
        
        _konsole.TypeEffect($"The Sales representive : That would be {n} Gold, would you like to proceed?");
        _konsole.TypeEffect($"{wizard.Name} take a look at his Gold purse, and {wizard.Name} put his hand inside the Gold purse");
        
        if (wizard.Gold > 0)
        {
            _konsole.TypeEffect($"{wizard.Name} sense the gold pieces towards his hand, and {wizard.Name} start counting the gold pieces");
            if (wizard.Gold >= n)
            {
                _konsole.TypeEffect($"{wizard.Name} counted {wizard.Gold} Gold pieces");
            }
            else
            {
                _konsole.TypeEffect($"{wizard.Name} counted {wizard.Gold} Gold pieces, but realized its was not enough pieces to purchase the items.");
                return;
            }
        }
        else
        {
            _konsole.TypeEffect($"{wizard.Name} realize that the Gold purse is empty");
            return;
        }
        
        var input = Console.ReadLine().ToLower();
        _konsole.TypeEffect($"{wizard.Name} : {input.ToUpperInvariant()}");
        
        if (input is "yes" or "y")
        {
            if (wizard.Gold >= n)
            {
                foreach (var element in ShoppingCart.Where(element => wizard.Gold <= element.PurchasePrice))
                {
                    wizard.Inventory.Add(element);
                    wizard.Gold -= element.PurchasePrice;
                }
            }
            else
            {
                _konsole.TypeEffect("The Sales representive : I'm sorry, you do not have enough gold to purchase the items in the shopping cart");
            }
        }

    }

    protected virtual void StealItem()
    {
        if(CalculateRate())
        {
            
            foreach (var element in ShoppingCart)
            {
                wizard.Inventory.Add(element);
            }
            
        }
        else
        {
            _konsole.TypeEffect($"As {wizard.Name} were caught stealing, the store owner notified the School about the behavior");
            //konsole.TypeEffect($" {wizard.House.proffesor} : {wizard.House} lost 200points !\nThis is not acceptable behavior !"); 
            //wizard.House.Points -= 200;
        }
        _konsole.WriteLine($"As {wizard.Name} passed by the store owner, {wizard.Name} went out of the store undetected!");
        _konsole.CleanConsole();
    }
    
    private void PurchaseItem(int price = 30)
    {
        var input = Console.ReadLine();
        
        // Switch statement to handle the user input
        switch (input)
        {
            case "-i":
                wizard.PrintInventory();
                break;
            
            case "-s":
                var itemName = input.Split(" ")[1];
                foreach (var element in wizard.Inventory.Where(i => i.Name == itemName))
                {
                    wizard.RemoveFromInventory(element);
                    wizard.Gold += element.Rarity * price;
                }
                break;
            
        }
    }

    internal void Checkout()
    {
        string[] array =
        [
            "Purchase the items in the shopping cart",
            "Steal the items in the shopping cart",
            "Sell the items in the Inventory"
        ];

        _konsole.CleanConsole();

        _konsole.TypeEffect("Before you exit the store, you take a look at the items in the shopping cart.");
        _konsole.WriteLine("");

        foreach (var element in ShoppingCart)
        {
            _konsole.WriteLine(
                $"Item: {element.Name} Type: {element.Type} Rarity: {element.Rarity} Price: {element.PurchasePrice}");
        }

        _konsole.WriteLine("");

        _konsole.TypeEffect(
            "A thought arises in {wizard.Name}'s mind, what would I like to do with the items in the shopping cart?!");

        for (var i = 0; i < array.Length; i++)
        {
            var txt = array[i];
            _konsole.TypeEffect($"Press {i + 1} To {array[i]}");
        }

        var input = _konsole.ReadKeyNumeric();
        _konsole.WriteLine($"As {wizard.Name} took an decision and started to walk towards the exit");

        switch (input.Key)
        {
            case ConsoleKey.D1:
                _konsole.TypeEffect(
                    $"As {wizard.Name} walks towards the exit he stops, and turn his face towards the sales representive.\nThe Sales repesentive faces towards {wizard.Name}, and asks");
                _konsole.TypeEffect(
                    "The Sales repesentive : Greetings, How can i provide my services for you today?\n Would you like to sell your items?, Would you like to Purchase an item?");
                _konsole.TypeEffect($"{wizard.Name} : I would like to purchase the items in the shopping cart");

                SellItem();
                break;

            case ConsoleKey.D2:
                _konsole.TypeEffect(
                    $"As {wizard.Name} walks towards the exit he stops, for a second, and turns around to see if the Shopkeeper is watching him, and then he proceed to walk out of the store");
                StealItem();
                break;

            case ConsoleKey.D3:

                _konsole.TypeEffect(
                    "As {_wizard.Name} walks towards the exit he stops, and turn his face towards the sales representive.\nThe Sales repesentive faces towards you, and asks");
                _konsole.TypeEffect(
                    "The Sales repesentive : Greetings, How can i provide my services for you today?\n Would you like to sell your items?, Would you like to Purchase an item?");

                // Ensure that the wizards inventory is empty
                if (wizard.Inventory.Count == 0)
                {
                    _konsole.TypeEffect(
                        $"{wizard.Name} opens up his inventory, and realizes that he do not have anything to sell the Sales repesentive !");

                }
                else
                {
                    PurchaseItem();
                }

                break;

        }
    }
    public void EnterStore()
    {
        
    }
    
}

