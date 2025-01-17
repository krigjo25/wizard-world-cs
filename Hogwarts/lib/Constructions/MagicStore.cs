//  Libraries used for the program 
using wizardWorld.lib.Items;
using wizardWorld.lib.Characters;
using wizardWorld.lib.TextWeaver;

namespace wizardWorld.lib.Constructions;

internal class MagicStore
{
    string[] wands = ["unicorn wand", "troll wand", "phoenix wand"];

    private readonly Konsole _konsole = new Konsole();
    private readonly Wizard _wizard;
    
    // List of items in the store
    private List<Baton> Wands = [];
    private List<Animal> Animals = [];
    private List<GeneralStore> StoreProduct = [];
    private List<GeneralStore> ShoppingCart { get; } = [];

    public MagicStore(Wizard wizard)
    {
        InitializeProducts();
        Console.WriteLine("Initialized!");
        _wizard = wizard;
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
    
    private void Checkout()
    {
        string[] array =
        [
            "Purchase the items in the shopping cart",
            "Steal the items in the shopping cart",
            "Sell the items in the Inventory"
        ];
        
        Console.Clear();

        _konsole.TypeEffect("Before you exit the store, you take a look at the items in the shopping cart.");
        foreach (var element in ShoppingCart)
        {
            _konsole.WriteLine($"Item: {element.Name} Type: {element.Type} Rarity: {element.Rarity} Price: {element.PurchasePrice}");
        }
        
        _konsole.TypeEffect("A thought arises in your mind, what would I like to do with the items in the shopping cart?!");
        
        for (var i = 0; i < array.Length; i++)
        {
            var txt = array[i];
            _konsole.TypeEffect($"Press {i+1} To {array[i]}");
        }
        
        var input = Console.ReadKey();
        _konsole.WriteLine("As you took an decision, you started to walk towards the exit");
        
        switch (input.Key)
        {
            case ConsoleKey.D1:
                _konsole.TypeEffect("As you're walking towards the exit you stop, and turn your face towards the sales representive.\nThe Sales repesentive faces towards you, and asks");
                _konsole.TypeEffect("The Sales repesentive : Greetings, How can i provide my services for you today?\n Would you like to sell your items?, Would you like to Purchase an item?");
                _konsole.TypeEffect($"{_wizard.Name} : I would like to purchase the items in the shopping cart");
                
                SellItem();
                return;
            
            case ConsoleKey.D2:
                _konsole.TypeEffect("As you're walking towards the exit you stop, for a second, and turns around to see if the Shopkeeper is watching you, and then you proceed to walk out of the store");
                StealItem();
                return;
            
            case ConsoleKey.D3:
                
                _konsole.TypeEffect("As you're walking towards the exit you stop, and turn your face towards the sales representive.\nThe Sales repesentive faces towards you, and asks");
                _konsole.TypeEffect("The Sales repesentive : Greetings, How can i provide my services for you today?\n Would you like to sell your items?, Would you like to Purchase an item?");
                
                // Ensure that the wizards inventory is empty
                if (_wizard.Inventory.Count == 0)
                {
                    _konsole.TypeEffect("You open up your inventory, and realizes that you do not have anything to sell the Sales repesentive !");

                }
                else
                {
                    PurchaseItem();
                }
                break;
            
        }
        
        // Sell item to the Customer
        foreach (var element in ShoppingCart.Where(element => _wizard.Gold <= element.PurchasePrice))
        {
            _wizard.Inventory.Add(element);
        }
        
        _konsole.TypeEffect("As you've finished the transaction, you hear\nthe sales repesentive says : Thank you for the purchase, welcome back !");
        Console.WriteLine("Thank you for using the MagicStore !");
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
        _konsole.TypeEffect($"{_wizard.Name} take a look at his Gold purse, and {_wizard.Name} put his hand inside the Gold purse");
        
        if (_wizard.Gold > 0)
        {
            _konsole.TypeEffect($"{_wizard.Name} sense the gold pieces towards his hand, and {_wizard.Name} start counting the gold pieces");
            _konsole.TypeEffect($"{_wizard.Name} counted {_wizard.Gold} Gold pieces");
            if (_wizard.Gold >= n)
            {
                _konsole.TypeEffect($"{_wizard.Name} counted {_wizard.Gold} Gold pieces");
            }
            else
            {
                _konsole.TypeEffect($"{_wizard.Name} do not have enough gold to purchase the items in the shopping cart");
                return;
            }
        }
        else
        {
            _konsole.TypeEffect($"{_wizard.Name} put his hand inside the Gold purse, and {_wizard.Name} realize that the Gold purse is empty");
            return;
        }
        
        var input = Console.ReadLine().ToLower();
        _konsole.TypeEffect($"{_wizard.Name} : {input.ToUpperInvariant()}");
        
        if (input is "yes" or "y")
        {
            if (_wizard.Gold >= n)
            {
                foreach (var element in ShoppingCart.Where(element => _wizard.Gold <= element.PurchasePrice))
                {
                    _wizard.Inventory.Add(element);
                    _wizard.Gold -= element.PurchasePrice;
                }
            }
            else
            {
                _konsole.TypeEffect("The Sales representive : I'm sorry, you do not have enough gold to purchase the items in the shopping cart");
            }
        }

    }
    
    private void StealItem()
    {
        if(CalculateRate())
        {
            
            foreach (var element in ShoppingCart)
            {
                
                _wizard.Inventory.Add(element);
            }
            
        }
        else
        {

            _konsole.TypeEffect($"As {_wizard.Name} were caught stealing, the store owner notified the School about the behavior");
            //konsole.TypeEffect($" {wizard.House.proffesor} : {wizard.House} lost 200points !\nThis is not acceptable behavior !"); 
            //wizard.House.Points -= 200;
        }
        _konsole.WriteLine($"As {_wizard.Name} passed by the store owner, {_wizard.Name} went out of the store undetected!");
        _konsole.CleanConsole();
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
            $"As suspicious as {_wizard.Name} are, {_wizard.Name} turn his face towards the sales representive\n The sales representive didn't face {_wizard.Name}. and wish him a beautiful day further.",
            $"As suspicious {_wizard.Name} are, {_wizard.Name} turn his face towards the sales representive\n The sales representive did face {_wizard.Name} and wish him a beautiful day further.",
            $"As {_wizard.Name} were about to exit the store, the store owner notices his suspicious behavior",
            $"As {_wizard.Name} were about to exit the store, the store owner notices a suspicious Clump in his sweater",
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
    
    private void PurchaseItem(int price = 30)
    {
        var input = Console.ReadLine();
        
        // Switch statement to handle the user input
        switch (input)
        {
            case "-i":
                _wizard.PrintInventory();
                break;
            
            case "-s":
                var itemName = input.Split(" ")[1];
                foreach (var element in _wizard.Inventory.Where(i => i.Name == itemName))
                {
                    _wizard.RemoveFromInventory(element);
                    _wizard.Gold += element.Rarity * price;
                }
                break;
            
        }
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

    private void PrintMenu(string type)
    {
        while (true)
        {
            _konsole.TypeEffect($"As {_wizard.Name} proceed to the {type} section, {_wizard.Name} takes a look at the available items in the section");
            _konsole.WriteLine("");
            
            //  Print the available items in the store
            foreach (var element in StoreProduct.Where(element => element.ItemType == type))
            {
                _konsole.TypeEffect($"{element.Name} Price tag: {element.PurchasePrice} Gold, Rarity: {element.Rarity}");
            }
            _konsole.WriteLine("");

            // Print the available options in the store
            foreach (var element in StoreProduct.Where(element => element.ItemType == type))
            {
                _konsole.TypeEffect($"Press {element.ID} to add a(n) {element.Name} to the shoppingCart.");
            }

            _konsole.TypeEffect("Press ESC or Q to exit\n Press L to go back to the previous section");
            _konsole.WriteLine("");

            // Prompt the user to select an option
            var input = Console.ReadKey();
            
            // Ensures that the key pressed is ESC or Q
            _konsole.Exit(input.Key);
           
            if (input.Key == ConsoleKey.L)
            {
                return;
            }
            
            //  Ensures that the key pressed is a number
            _konsole.NumericError(input.KeyChar.ToString());

            // Add the selected item to the shopping cart
            foreach (var element in StoreProduct.Where(element => element.ID == int.Parse(input.KeyChar.ToString())).ToList())
            {

                // Add the selected item to the shopping cart
                ShoppingCart.Add(element);
                _konsole.WriteLine("");
                _konsole.TypeEffect($"Added A {element.Name} to the shopping cart");
                
                //  Remove the element from the section
                StoreProduct.Remove(element);
            }
        }
    }
    
    public void PrintWelcomeMessage()
    {
        string[] entry = ["Animal", "Wizard Wand", "Check out"];
        while (true)
        {
            _konsole.CleanConsole();
            
            if (ShoppingCart.Count > 0)
            {
                _konsole.TypeEffect($"As {_wizard.Name} went away from the section, {_wizard.Name} take another look around, and decides whether to checkout or proceed to another section in the store.");
            }
            else
            {
                _konsole.TypeEffect($"As {_wizard.Name} enter the store, {_wizard.Name} stop for a second, and take a look around the store");
            }
            
            // Print the available items in the store
            for (int i = 0; i < entry.Length; i++)
            {
                _konsole.TypeEffect(i % 3 == 0 && i+1 != 1? $"Press {i + 1} to proceed to {entry[i]} ." : $"Press {i + 1} to proceed to  {entry[i]} Section");
            }
            _konsole.TypeEffect("Press ESC / q to exit");
            
            // Prompt the user to select an option
            var input = Console.ReadKey();

            // Ensures that the key pressed is ESC or Q
            switch (input)
            {
                
            }
            _konsole.Exit(input.Key);
            
            //  Ensures that the key pressed is a number
            _konsole.NumericError(input.KeyChar.ToString());
            
            // Switch statement to handle the user input
            switch (input.Key)
            {
                
                case ConsoleKey.D1:
                    
                    // Print the available animals in the store
                    PrintMenu("Animal");
                    break;
                
                case ConsoleKey.D2:
                    
                    // Print the available wands items in the store
                    PrintMenu("Wand");
                    
                    break;
                
                case ConsoleKey.D3:
                    
                    //  Ensure that the Shopping cart is not empty
                    if (ShoppingCart.Count > 0)
                    {
                        _konsole.CleanConsole();
                        
                        // Checkout the items in the shopping cart
                        Checkout();
                        return;
                    }
                    
                    Console.WriteLine($"{_wizard.Name} have no items in your shopping cart !");
                    break;
                
                default:
                    continue;
            }
        }
    }
}

