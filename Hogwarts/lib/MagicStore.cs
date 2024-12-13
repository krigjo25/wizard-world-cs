namespace Hogwarts.lib;

internal class MagicStore
{
    string[] animals = ["Owl", "Rat"];
    string[] misc = ["Animal", "Wizard Wand", "Misc", "Check out"];
    string[] wands = ["unicorn wand", "troll wand", "phoenix wand"];

    private List<string> ShoppingCart = [];
    public void PrintWelcomeMessage()
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
                
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Here is our misc Items !");
                    
                    PrintMenu(misc);
                    break;
                
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Here is our beautiful wands !");
                    
                    PrintMenu(wands);
                    break;
                
                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine("Student is walking to the Check out point!");
                    
                    Checkout();
                    break;
                
                default:
                    continue;
            }
        }
    }

    private void PrintMenu(string[] arg)
    {
        while (true)
        {
            for (int i = 0; i < arg.Length; i++)
            {
                Console.WriteLine($"Press {i+1} to add an {arg[i]} to the shoppingCart");
            }
            
            Console.WriteLine("Press ESC / q to exit");
            var input = Console.ReadKey();
            
            // Ensures that the key pressed is ESC or Q
            if (input.Key is ConsoleKey.Q or ConsoleKey.Escape)
            {
                return;
            }
            // Ensures that the pressed Key will be added to class
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    ShoppingCart.Add(arg[1]);
                    Console.Clear();
                    break;
                
                case ConsoleKey.D2:
                    ShoppingCart.Add(arg[(int) char.GetNumericValue(input.KeyChar)]);
                    break;
                
                case ConsoleKey.D3:
                    ShoppingCart.Add(arg[(int) char.GetNumericValue(input.KeyChar)]);
                    break;
            }
            
        }
    }

    private void Checkout()
    {
        Console.Clear();
        foreach (var item in ShoppingCart)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Thank you for using the MagicStore !");
        
    }
}