using wizardWorld.lib.Items;
namespace wizardWorld.lib.Characters;

public class NPC : Wizard

{
    public NPC(string name, int gold, int lvl = 1, Baton? wand = null, Animal? pet = null) : base(name, gold, lvl, wand, pet)
    {
    }
}