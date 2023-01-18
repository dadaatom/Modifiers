using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdedInt : ModdedValue
{
    public int Value;
    
    public ModdedInt() : this(0) { }

    public ModdedInt(int value) : this(value, new PriorityList<Modifier>()) { }

    public ModdedInt(int value, PriorityList<Modifier> modifiers) : base(modifiers)
    {
        this.Value = value;
        //this.modifiers = modifiers;
    }
    
    public int Get()
    {
        int modifiedValue = Value;
        foreach (Modifier modifier in modifiers.GetList())
        {
            modifiedValue = (int)modifier.Compute(modifiedValue);
        }

        return modifiedValue;
    }

    public void Set(int value)
    {
        Value = value;
    }

    public static implicit operator int(ModdedInt moddedInt)
    {
        return moddedInt.Get();
    }

    public static ModdedInt operator +(ModdedInt moddedInt, int value)
    {
        return new ModdedInt(moddedInt.Value + value, moddedInt.modifiers);
    }
    
    public static ModdedInt operator -(ModdedInt moddedInt, int value)
    {
        return new ModdedInt(moddedInt.Value - value, moddedInt.modifiers);
    }
    
    public static ModdedInt operator *(ModdedInt moddedInt, int value)
    {
        return new ModdedInt(moddedInt.Value * value, moddedInt.modifiers);
    }
    
    public static ModdedInt operator /(ModdedInt moddedInt, int value)
    {
        return new ModdedInt(moddedInt.Value / value, moddedInt.modifiers);
    }
    
    public static ModdedInt operator %(ModdedInt moddedInt, int value)
    {
        return new ModdedInt(moddedInt.Value % value, moddedInt.modifiers);
    }
}
