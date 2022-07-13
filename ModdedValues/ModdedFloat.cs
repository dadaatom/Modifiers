using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ModdedFloat : ModdedValue
{
    public float value;
    
    public ModdedFloat() : this(0) { }

    public ModdedFloat(float value) : this(value, new PriorityList<Modifier>()) { }

    public ModdedFloat(float value, PriorityList<Modifier> modifiers) : base(modifiers)
    {
        this.value = value;
    }
    
    public float Get()
    {
        float modifiedValue = value;
        foreach (Modifier modifier in modifiers.GetList())
        {
            modifiedValue = modifier.Compute(modifiedValue);
        }

        return modifiedValue;
    }
    
    public static implicit operator float(ModdedFloat moddedFloat)
    {
        return moddedFloat.Get();
    }
}

