//  The program is a prototype of a console application that will simulate a wizard world
//  Libraries used for the program 
using wizardWorld.lib;
using wizardWorld.lib.Characters;
using wizardWorld.lib.Constructions;

internal class ConsoleAPP
{
    public static void Main(string[] args)
    {
 
        List<Wizard> Wizards = [];
        
        var ms = new MagicStore();
        
        var wizard = new Wizard( "Ronald Kolerius Wiltersen",1000);
        
        Wizards.Add(wizard);
        
        //  A console to do something
        
        
        
        
        // Print the students
        foreach (var student in Wizards)
        {
            // Dette er et objekt
            Console.WriteLine(student);

            Console.WriteLine(student.Name);
            Console.WriteLine(student.Gold);
            
        }
        
        ms.PrintWelcomeMessage(wizard);

    }
}