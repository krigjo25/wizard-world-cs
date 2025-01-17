//  The program is a prototype of a console application that will simulate a wizard world
//  Libraries used for the program 
using wizardWorld.lib;
using wizardWorld.lib.Characters;
using wizardWorld.lib.Constructions;
using wizardWorld.lib.TextWeaver;

internal class ConsoleAPP
{
    
    public static void Main(string[] args)
    {
        //  A list of wizards
        List<Wizard> Wizards = [];
        
        
        //  Initializing a wizard
        var wizard = new Wizard( "Ronald Kolerius Wiltersen",1000);
        
        //  Initializing a magic store
        var ms = new Store(wizard);
        Wizards.Add(wizard);
        
        //  Introduce the user to the wizard world

        //  Intro
        ms.PrintWelcomeMessage();
        
        //  Proceeds to the School of Magic
        
        // At the School of Magic
        

    }

    public static void GameIntroduction()
    {
        Konsole konsole = new Konsole();
    
        konsole.TypeEffect("Once upon a time...", 75);
        Thread.Sleep(50);
        konsole.TypeEffect("In a distant land", 75);
        
    }
}