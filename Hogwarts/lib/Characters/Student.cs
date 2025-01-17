using wizardWorld.lib.Items;

namespace wizardWorld.lib.Characters;

public class Student : Wizard
{
    private object _house;
    public object House
    {
        get => _house;
        set => _house = value;
    }

    public Student(string name, int gold, int lvl = 1, Baton? wand = null, Animal? pet = null, object? house = null) : base(name, gold, lvl, wand, pet)
    {
        _house = house;
    }
}