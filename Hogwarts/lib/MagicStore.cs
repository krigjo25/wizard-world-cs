using System.Threading.Channels;

namespace Hogwarts.lib;

internal class MagicStore
{
    string[] animals = ["Owl", "Rat"];
    string[] misc = ["Animal", "Wizard Wand", "Misc", "Check out", "Steal Item(s)"];
    string[] wands = ["unicorn wand", "troll wand", "phoenix wand"];

    private List<Items> Items = [];
    private List<Items> ShoppingCart = [];
    
    public MagicStore()
    {
        InitializeProducts();
    }

    public void InitializeProducts()
    {
        // Available items in the store
        Items.Add(new StoreItems("Cat", "Land", 30, "Owl", 1));
        Items.Add(new StoreItems("Owl", "Flying", 50, "Rat", 1));
        Items.Add(new StoreItems("Rat", "Land", 25, "Cat", 1));
        Items.Add(new StoreItems("Toad", "Land/sea", 10, "Toad", 1));
        
        //  Available wands in the store
        Items.Add(new StoreItems("Troll Wand", "Dark wand",45, "", 1));
        Items.Add(new StoreItems("Unicorn wand", "Light, wand", 30, "", 1));
        Items.Add(new StoreItems("Phoenix wand", "Fire wand", 3000, "", 1));
        
        // Available misc items in the store
    }
    public void PrintWelcomeMessage(Wizard wizard)
    {
        
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the MagicStore !");
            
            for (int i = 0; i < misc.Length; i++)
            {
                Console.WriteLine(i % 3 == 0 ? $"Press {i + 1} to {misc[i]}." : $"Press {i + 1} to view  {misc[i]} Menu");
            }
            Console.WriteLine("Press ESC / q to exit");
            var input = Console.ReadKey();

            // Ensures that the key pressed is ESC or Q
            if (input.Key is ConsoleKey.Escape or ConsoleKey.Q)
            {
                return;
            }
            
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Here is our beautiful animals !");
                    
                    PrintMenu(animals);
                    break;
                
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Here is our misc Items !");
                    
                    PrintMenu(misc);
                    break;
                
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Here is our beautiful wands !");
                    PrintMenu(wands);
                    break;
                
                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine("Student walking towards the Check out point !");
                    
                    Checkout(wizard);
                    return;
                
                case ConsoleKey.D5:
                    Console.WriteLine("Student is walking towards the exit");
                    StealItem(wizard);
                    return;
                
                case ConsoleKey.D6:
                    Console.WriteLine("Student is walking towards the Checkout point !");
                    SellItem(wizard);
                    return;
                
                default:
                    continue;
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

    private void PrintMenu(string[] arg)
    {
        while (true)
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"Press {Items.Count} to add an {item} to the shoppingCart");
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
        const int sellprice = 30;
        
        Console.WriteLine("Welcome to the MagicStore CheckOutPoint !");
        Console.WriteLine("What would you like to sell? !");
        
        Console.WriteLine("What would you like to sell?!");
        Console.WriteLine("-s <name> to sell an item");
        Console.WriteLine("-i to view your inventory");
        
        var input = Console.ReadLine();
        
        if (input == "-i")
        {
            wizard.PrintInventory();
        }
        else if (input.StartsWith("-s"))
        {
            var itemName = input.Split(" ")[1];
            foreach (var element in wizard.Inventory.Where(i => i.Name == itemName))
            {
                
                wizard.RemoveFromInventory(element);
                wizard.Gold += element.Rarity * sellprice;
            }
        }
        
        foreach (var element in wizard.Inventory)
        {
        }
    }
    
    private void Checkout(Wizard wizard)
    {
        Console.Clear();
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
}