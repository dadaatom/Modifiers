namespace Modifiers
{
    public abstract class ModdedValue
    {
        public PriorityList<Modifier> modifiers;

        public ModdedValue() : this(new PriorityList<Modifier>()) { }

        public ModdedValue(PriorityList<Modifier> modifiers)
        {
            this.modifiers = modifiers;
        }
    }
}
