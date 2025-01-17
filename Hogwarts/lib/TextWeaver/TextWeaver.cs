namespace wizardWorld.lib.TextWeaver;

public class Konsole
{
    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
    
    public void Write(string text)
    {
        Console.Write(text);
    }

    public void TypeEffect(string text, int ms = 75)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            System.Threading.Thread.Sleep(ms);
        }
        Console.WriteLine();
    }
    
    public void CleanConsole()
    {
        Console.Clear();
    }
    
    public void NumericError( string c)
    {
        
        try
        {
            // Ensures that the key pressed is a number
            if (!int.TryParse(c, out int n))
            {
                throw new ArgumentException($"Error : {c} is not an numeric value, please enter a number");
            }
        }
        
        catch (ArgumentException e)
        {
            CleanConsole();
            
            //  Configure the Console to display the error message in red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Environment.Exit(134);
            

        }
    }
    
    public void Exit(object c)
    {

        if ((int)c == (int)ConsoleKey.Q || (int)c == (int)ConsoleKey.Escape)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Exiting, with the status code 0");
            Environment.Exit(0);
        }
    }
}