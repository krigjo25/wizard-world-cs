//  Libraries used for the program 
using wizardWorld.lib;
using wizardWorld.lib.Items;
using wizardWorld.lib.Characters;
using wizardWorld.lib.Constructions;
using wizardWorld.lib.TextWeaver;

namespace wizardWorld.lib.Constructions;

internal class MagicStore
{
    string[] wands = ["unicorn wand", "troll wand", "phoenix wand"];
    
    Konsole konsole = new Konsole();
    
    // List of items in the store
    private List<Baton> Wands = [];
    private List<Animal> Animals = [];
    private List<GeneralStore> StoreProduct = [];
    private List<GeneralStore> ShoppingCart { get; } = [];

    public MagicStore()
    {
        InitializeProducts();
        Console.WriteLine("Initialized!");
    }
    
    private void InitializeProducts()
    {
        //  Initializing animals
        Animals.Add(new Animal("Owl", 1, "Aerial"));
        Animals.Add(new Animal("Cat",  1));
        Animals.Add(new Animal("Rat", 1));
        Animals.Add(new Animal("Toad", 1));

        foreach (var element in Animals)
        {
            Console.WriteLine($"Animal: {element.Organism} Type: {element.Type} Rarity: {element.Rarity}");
        }
        
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
    
    private void Checkout(Wizard wizard)
    {
        string[] array =
        [
            "Purchase the items in the shopping cart",
            "Steal the items in the shopping cart",
            "Sell the items in the Inventory"
        ];
        
        Console.Clear();

        konsole.WriteLine("Looking at the items in your shopping cart !");
        Console.WriteLine();
        foreach (var element in ShoppingCart)
        {
            konsole.WriteLine($"Item: {element.Name} Type: {element.Type} Rarity: {element.Rarity} Price: {element.PurchasePrice}");
        }
        Console.WriteLine("A thought arises in your mind, what would I like to do with the items in the shopping cart?!");
        
        for (var i = 0; i < array.Length; i++)
        {
            var txt = array[i];
            konsole.TypeEffect($"Press {i} {array[i]}");
        }
        
        var input = Console.ReadKey();
        konsole.WriteLine("As you took an decision, you started to walk towards the Sales repesenative");
        switch (input.Key)
        {
            
            case ConsoleKey.D1:
                PurchaseItem(wizard);
                return;
            
            case ConsoleKey.D2:
                StealItem(wizard);
                return;
            
            case ConsoleKey.D3:
                
                if (wizard.Inventory.Count == 0)
                {
                    Console.WriteLine("There is no items in the inventory to sell !");
                    SellItem(wizard);
                    break;
                }
                
                
                return;
            
        }
        Console.WriteLine("Welcome to the MagicStore CheckOutPoint !");
        
        // Sell item to the Customer
        foreach (var element in ShoppingCart)
        {
            if (wizard.Gold <= element.PurchasePrice)
            {
                wizard.Inventory.Add(element);
            }
        }
        Console.WriteLine("Thank you for using the MagicStore !");
    }
    private void SellItem(Wizard wizard)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the MagicStore CheckOutPoint !");
        Console.WriteLine("Are you sure you would like to purchase items in your shopping cart?!");
        var input = Console.ReadLine().ToLower();
        
        if (input is "yes" or "y")
        {
            foreach (var element in ShoppingCart.Where(element => wizard.Gold <= element.PurchasePrice))
            {
                wizard.Inventory.Add(element);
                wizard.Gold -= element.PurchasePrice;
            }
        }
    }
    private void StealItem(Wizard wizard)
    {
        // Sucsess rate
        var decrease = (decimal)(10.1 * ShoppingCart.Count / 100.0);
        
        // Ranomize a boolean value
        
        
        if(true)
        {
            string [] array = [
                "As suspicious you are, you turn your face towards the sales representive, and wish him a beautiful day further.",
                "Thank you said the representive, have a beautiful  day !",
                "[ ! ] The representive did not notice you, as you walked out of the store with the items [ ! ]"
            ];
            foreach (var element in array)
            {
                konsole.TypeEffect(element);
            }
            
            foreach (var element in ShoppingCart)
            {
                
                wizard.Inventory.Add(element);
            }
            
        }
        else
        {
            int n = new Random().Next(0, 3);
            string [] array = [
                "As you were about to exit the store, the store owner notices your suspicious behavior",
                "As you were about to exit the store, the store owner notices a suspicious Clump in your sweater",
                "As suspicious you are, you turn your face towards the sales representive, and wish him a beautiful day further.",
                "Thank you said the representive, have a beautiful  day !",
                "[ ! ] The representive did not notice you, as you walked out of the store with the items [ ! ]"
                ];
            konsole.TypeEffect(array[n]);
            //konsole.TypeEffect($" {student.House.proffesor} : {student.House} lost 200points !\nThis is not acceptable behavior !");
            //student.House.Points -= 200;
        }
        Console.WriteLine("You went out of the store undetected !");
        konsole.CleanConsole();
    }
    private void PurchaseItem(Wizard wizard, int price = 30)
    {
        Console.WriteLine("Welcome to the MagicStore CheckOutPoint !");

        Console.WriteLine("What would you like to sell?!");
        Console.WriteLine("-s <name> to sell an item");
        Console.WriteLine("-i to view your inventory");
        
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

            // Print the available items in the store
            foreach (var element in StoreProduct.Where(element => element.ItemType == type))
            {
                Console.WriteLine($"Press {element.ID} to add a(n) {element.Name} to the shoppingCart");
            }

            Console.WriteLine("Press ESC or Q to exit");

            // Prompt the user to select an option
            var input = Console.ReadKey();

            // Ensures that the key pressed is ESC or Q
            if (input.Key is ConsoleKey.Escape or ConsoleKey.Q) return;

            // Ensures that the key pressed is a number
            if (!int.TryParse(input.KeyChar.ToString(), out var n)) return;

            //  Converting the key pressed to an integer
            var i = int.Parse(input.KeyChar.ToString());

            // Add the selected item to the shopping cart
            foreach (var element in StoreProduct.Where(element => element.ID == i))
            {

                // Add the selected item to the shopping cart
                ShoppingCart.Add(element);
                Console.Clear();
                Console.WriteLine($"Added A {element.Name} to the shopping cart");
            }
        }
    }
    
    public void PrintWelcomeMessage(Wizard wizard)
    {
        string[] entry = ["Animal", "Wizard Wand", "Check out"];
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the MagicStore !");
            
            // Print the available items in the store
            for (int i = 0; i < entry.Length; i++)
            {
                Console.WriteLine(i % 3 == 0 && i+1 != 1? $"Press {i + 1} to proceed to {entry[i]} ." : $"Press {i + 1} to proceed to  {entry[i]} Section");
            }
            Console.WriteLine("Press ESC / q to exit");
            
            // Prompt the user to select an option
            var input = Console.ReadKey();

            // Ensures that the key pressed is ESC or Q
            if (input.Key is ConsoleKey.Escape or ConsoleKey.Q)
            {
                return;
            }
            
            // Switch statement to handle the user input
            switch (input.Key)
            {
                
                case ConsoleKey.D1:
                    //Console.Clear();
                    Console.WriteLine("Here is our beautiful animals !");
                    
                    // Print the available animals in the store
                    PrintMenu("Animal");
                    break;
                
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Here is our beautiful wands !");
                    
                    // Print the available wands items in the store
                    PrintMenu("Wand");
                    
                    break;
                
                case ConsoleKey.D3:
                    
                    //  Ensure that the Shopping cart is not empty
                    if (ShoppingCart.Count > 0)
                    {
                        Console.Clear();
                        
                        // Checkout the items in the shopping cart
                        Checkout(wizard);
                        return;
                    }
                    
                    Console.WriteLine("You have no items in your shopping cart !");
                    break;
                
                default:
                    continue;
            }
        }
    }
}

