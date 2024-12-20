using Hogwarts.lib;

internal class ConsoleAPP
{
    public static void Main(string[] args)
    {
        //List<Huffelpuff> huffelpus = new();
        //List<Griffindor> griffindors = new();
        //List<Slytherin> slytherin = new();
        //List<Ravenclaw> ravenclaw = new();
        List<Student> students = [];
        
        var ms = new MagicStore();
        
        var pupil = new Student( "Ronald Kolerius Wiltersen",1000);
        
        students.Add(pupil);
        
        //  A console to do something
        
        
        
        
        // Print the student
        foreach (var student in students)
        {
            // Dette er et objekt
            Console.WriteLine(student);

            Console.WriteLine(student.Name);
            Console.WriteLine(student.Gold);
            
        }
        
        ms.PrintWelcomeMessage(pupil);

    }
}