//  Interactive menu for the user to navigate through the game
using wizardWorld.lib.Characters;
using wizardWorld.lib.TextWeaver;

namespace wizardWorld.lib.Constructions;

public class Menu
{
    private readonly Wizard _wizard;
    private readonly Konsole _konsole = new Konsole();
    private readonly Store _store;

    public Menu(Wizard wizard, Store store)
    {
        _store = store;
        _wizard = wizard;
        
    }
    
    private void PrintMenu(string type)
    {
        while (true)
        {
            _konsole.CleanConsole();
            
            if (_store.ShoppingCart.Count > 0)
            {
                _konsole.TypeEffect($"{_wizard.Name} takes another look around...");
            }
            else
            {
                _konsole.TypeEffect($"As {_wizard.Name} proceed to the {type} section, {_wizard.Name} takes a look at the available items in the section");
            }
           
            _konsole.WriteLine("");
            
            //  Print the available items in the store
            foreach (var element in _store.StoreProduct.Where(element => element.ItemType == type))
            {
                _konsole.TypeEffect($"{element.Name} Price tag: {element.PurchasePrice} Gold, Rarity: {element.Rarity}");
            }
            _konsole.WriteLine("");

            // Print the available options in the store
            foreach (var element in _store.StoreProduct.Where(element => element.ItemType == type))
            {
                _konsole.TypeEffect($"Press {element.ID} to add a(n) {element.Name} to the shoppingCart.");
            }

            _konsole.TypeEffect("Press ESC or Q to exit\nPress L to go back to the previous section");
            _konsole.WriteLine("");

            // Prompt the user to select an numeric option
            var input = _konsole.ReadKeyNumeric(true);
           
            if (input.Key == ConsoleKey.L)
            {
                return;
            }
            
            // Add the selected item to the shopping cart
            foreach (var element in _store.StoreProduct.Where(element => element.ID == int.Parse(input.KeyChar.ToString())).ToList())
            {

                // Add the selected item to the shopping cart
                _store.ShoppingCart.Add(element);
                _konsole.WriteLine("");
                _konsole.TypeEffect($"{_wizard.Name} Added A {element.Name} to the shopping cart");
                
                //  Remove the element from the section
                _store.StoreProduct.Remove(element);
            }
            _konsole.CleanConsole();
        }
    }
    
    public void PrintWelcomeMessage()
    {
        string[] entry = ["Animal", "Wizard Wand", "Check out"];
        while (true)
        {
            _konsole.CleanConsole();
            
            if (_store.ShoppingCart.Count > 0)
            {
                _konsole.TypeEffect($"As {_wizard.Name} went away from the section, {_wizard.Name} take another look around, and decides whether to checkout or proceed to another section in the store.");
            }
            else
            {
                _konsole.TypeEffect($"As {_wizard.Name} enter the store, {_wizard.Name} stop for a second, and take a look around the store");
            }
            
            // Print the available sections in the store
            for (int i = 0; i < entry.Length; i++)
            {
                _konsole.TypeEffect(i % 3 == 0 && i+1 != 1? $"Press {i + 1} to proceed to {entry[i]} ." : $"Press {i + 1} to proceed to  {entry[i]} Section");
            }
            _konsole.TypeEffect("Press ESC / q to exit");
            
            // Prompt the user to select an numeric option
            var input = _konsole.ReadKeyNumeric();
            
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
                    if (_store.ShoppingCart.Count > 0)
                    {
                        _konsole.CleanConsole();
                        
                        // Checkout the items in the shopping cart
                        _store.Checkout();
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