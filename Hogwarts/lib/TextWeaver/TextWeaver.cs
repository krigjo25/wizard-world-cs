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
}