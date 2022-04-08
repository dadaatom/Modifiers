using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdedInt : ModdedValue
{
    public int value;
    
    public ModdedInt() : this(0) { }

    public ModdedInt(int value) : this(value, new PriorityList<Modifier>()) { }

    public ModdedInt(int value, PriorityList<Modifier> modifiers) : base(modifiers)
    {
        this.value = value;
        //this.modifiers = modifiers;
    }
    
    public int Get()
    {
        int modifiedValue = value;
        foreach (Modifier modifier in modifiers.GetList())
        {
            modifiedValue = (int)modifier.Compute(modifiedValue);
        }

        return modifiedValue;
    }
    
    public static implicit operator int(ModdedInt moddedInt)
    {
        return moddedInt.Get();
    }
}
