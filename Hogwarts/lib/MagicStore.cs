namespace Hogwarts.lib;

internal class MagicStore
{
    string[] animals = ["Owl", "Rat"];
    string[] misc = ["Animal", "Wizard Wand", "Misc", "Check out", "Steal Item(s)"];
    string[] wands = ["unicorn wand", "troll wand", "phoenix wand"];

    private List<StoreItems> Items = [];
    private List<StoreItems> ShoppingCart = [];
    public void PrintWelcomeMessage(Wizard wizard)
    {
        Items.Add(new StoreItems("Owl", "Animal", 25));
        Items.Add(new StoreItems("Rat", "Animal", 10));
        
        Items.Add(new StoreItems("Unicorn wand", "wand", 30));
        Items.Add(new StoreItems("Troll Wand", "wand", 45));
        Items.Add(new StoreItems("Phoenix wand", "wand", 3000));
        
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

    private void Checkout(Wizard wizard)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the MagicStore CheckOutPoint !");
        
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