using System;
using System.Collections.Generic;

namespace Modifiers
{
    [Serializable]
    public abstract class ModdedValue
    {
        public PriorityList<Modifier> Modifiers;

        public ModdedValue() : this(new PriorityList<Modifier>()) { }

        public ModdedValue(PriorityList<Modifier> modifiers)
        {
            this.Modifiers = modifiers;
        }

        public void RemoveModifierByLabel(string label)
        {
            List<Modifier> modifiers = Modifiers.GetList();

            int count = modifiers.Count;
            
            for (int index = 0; index < count; index++)
            {
                if (modifiers[index].Label == label)
                {
                    Modifiers.Remove(index);
                    
                    index--;
                    count--;
                }
            }
        }
    }
}
