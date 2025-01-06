using System.Threading.Channels;

namespace Hogwarts.lib;

internal class MagicStore
{
    string[] animals = ["Owl", "Rat", "Cat", "Toad"];
    string[] misc = ["Animal", "Wizard Wand", "Misc", "Check out"];
    string[] wands = ["unicorn wand", "troll wand", "phoenix wand"];

    // List of items in the store
    private List<Wand> Wands = [];
    public List<Animal> Animals = [];
    public List<GeneralStore> Items = [];
    public List<GeneralStore> ShoppingCart = [];
    public MagicStore()
    {
        InitializeProducts();
    }

    private void InitializeProducts()
    {
        
        // Available Animals in the store
        for (int i = 0; i < animals.Length; i++)
        {
            if (animals[i] == "Owl")
            {
                Animals.Add(new Animal(animals[i], "Flying", 1));
            }
            else
            {
                Animals.Add(new Animal(animals[i], "Land", 1 ));
            }
        }
        
        for (int i = 0; i < wands.Length; i++)
        {
            if (wands[i] == "Unicorn wand")
            {
                Wands.Add(new Wand(wands[i], "Light", 1));
            }
            else
            {
                Wands.Add(new Wand(wands[i], "Dark", 1));
            }
        }

        foreach (var element in Animals)
        {
            Items.Add(new GeneralStore(CalculatePrice(element.Rarity, element.Type), element.Name, element.Type, element.Rarity));
            
        }
        foreach (var element in Wands)
        {
            Items.Add(new GeneralStore(CalculatePrice(element.Rarity, element.Type), element.Name, element.Type, element.Rarity));
        }
        
        // Available misc items in the store
    }
    
    private void Checkout(Wizard wizard)
    {
        Console.Clear();
        
        Console.WriteLine();
        var input = Console.ReadKey();

        switch (input.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine("Student is walking towards the Sales repesenative");
                PurchaseItem(wizard);
                break;
            
            case ConsoleKey.D2:
                Console.WriteLine("Student is walking towards the exit");
                StealItem(wizard);
                break;
            
            case ConsoleKey.D3:
                Console.WriteLine("Student is walking towards the Sales repesenative");
                SellItem(wizard);
                break;
            
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
    private void PrintMenu(string[] arg)
    {
        while (true)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"Press {i+1} to add an {Items[i].Name} to the shoppingCart");
            }
            foreach (var item in Items)
            {
                
            }
            Console.WriteLine("Press ESC / q to exit");
            
            var input = Console.ReadKey();
            
            // Ensures that the key pressed is ESC or Q
            if (input.Key is ConsoleKey.Q or ConsoleKey.Escape)
            {
                return;
            }
            // Add selected item to the Shopping cart
            foreach (var element in Items.Where(i => i.Name == arg[(int)char.GetNumericValue(input.KeyChar) - 1]))
            {
                ShoppingCart.Add(element);
                break;
            }
            
        }
    }
    
    private void SellItem(Wizard wizard)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the MagicStore CheckOutPoint !");
        Console.WriteLine("Are you sure you would like to purchase items in your shopping cart?!");
        var input = Console.ReadLine().ToLower();
        
        if (input == "yes" || input == "y")
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
        // Ranomize a boolean value
        Console.Clear();
        
        if(true)
        {
            Console.WriteLine("You stole your shopping cart !");
            
            foreach (var element in ShoppingCart)
            {
                
                wizard.Inventory.Add(element);
            }
            
        }
        else
        {
            //Console.WriteLine("You got dectected by the store Owner !");
            //Console.WriteLine($" {student.House.proffesor} : {student.House} lost 200points !\nThis is not acceptable behavior !");
            //student.House.Points -= 200;
        }
        Console.WriteLine("You went out of the store undetected !");
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

    public void PrintWelcomeMessage(Wizard wizard)
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the MagicStore !");
            
            // Print the available items in the store
            for (int i = 0; i < misc.Length; i++)
            {
                Console.WriteLine(i % 3 == 0 && i+1 != 1? $"Press {i + 1} to proceed to {misc[i]}." : $"Press {i + 1} to view  {misc[i]} Menu");
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
                    Console.Clear();
                    Console.WriteLine("Here is our beautiful animals !");
                    
                    // Print the available animals in the store
                    PrintMenu(animals);
                    break;
                
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Here is our misc Items !");
                    
                    // Print the available misc items in the store
                    PrintMenu(misc);
                    break;
                
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Here is our beautiful wands !");
                    
                    // Print the available wands in the store
                    PrintMenu(wands);
                    break;
                
                case ConsoleKey.D4:
                    
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

