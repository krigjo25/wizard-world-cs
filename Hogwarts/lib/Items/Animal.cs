//  Libraries used for the program 
using wizardWorld.lib.Characters;

namespace wizardWorld.lib.Items;

public class Animal: Item
{
    //private string Race { get; set; }
    private string _organism;
    
    public string Organism
    {
        get => _organism;
        set => _organism = value;
    }
    
    public Animal( string organism, int rarity = 0, string type= "Ground-Dweller", string description = "", string name = "")
        : base(name, type, description,rarity)
    {
        _organism = organism;
    }
    public void ChangeName(string name)
    {
        Name = name;
    }
    
    public virtual void SendSound()
    {
        // Send the sound
    }
    
    public void SendMessage(Wizard? from, Wizard? to)
    {
        if (from == null || to == null)
        {
            Console.WriteLine("Can not send message");
        }
        //  Ensure The sender is not the receiver
        switch (Type)
        {
            case "Ground-Dweller":
                Console.WriteLine("Can not send message");
                break;
            
            case "Aerial":

                    //  Ensure that the message is not sent to the sender
                        if (to.Name != from.Name)
                        {
                            //  Iteration through the list of wizards which has
                            foreach (var animal in from animal in @from.Animals
                                     from fromanimal in @from.Animals
                                     where animal.Type == fromanimal.Type
                                     select animal)
                            {
                                // Send message object to the wizard
                            }
                        }

                    break;
        }
    }

    public virtual void Transport(Wizard student)
    {
        // Transport the student
    }
}