//  The program is a prototype of a console application that will simulate a wizard world
//  Libraries used for the program 
using wizardWorld.lib;
using wizardWorld.lib.Characters;
using wizardWorld.lib.Constructions;
using wizardWorld.lib.TextWeaver;

internal class ConsoleAPP
{
     private static Konsole _konsole = new Konsole();
     private static Student _student = new Student( "Ronald Kolerius Wiltersen",1000);
    public static void Main(string[] args)
    {
        //  A list of wizards
        List<Student> Wizards = [];
        
        
        //  Initializing a wizard
        
        
        //  Initializing a magic store
        var ms = new Store(_student);
        Wizards.Add(_student);
        
        //  Introduce the user to the wizard world
        GameIntroduction();
        
        //  Intro
        
        
        
        //  Proceeds to the School of Magic
        
        // At the School of Magic
        

    }

    public static void GameIntroduction()
    {
        
    
        _konsole.TypeEffect("Once upon a time...", 75);
        Thread.Sleep(50);
        _konsole.TypeEffect("In a distant land", 75);
        
    }

    public static void Hogsmade(Store store)
    {
        var city = "city";
        
        _konsole.TypeEffect($"As {_student.Name} walk into the {city}, {_student.Name} looks around, and is amused of the constructions around him.", 75);
        _konsole.TypeEffect($"The city is filled with different stores, different creatures. {_student.Name} is excited to explore the {city}.", 75);
        _konsole.TypeEffect($"In front of {_student.Name}, stands a big old and dark house.. {_student.Name}, peeks through the window, and enters the door.", 75);
        
        store.EnterStore();
    }
}