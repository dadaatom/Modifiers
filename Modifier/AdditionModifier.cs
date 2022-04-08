using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionModifier : Modifier
{
    public float Value { get; }
    
    public AdditionModifier(float value) : this("", 0, value) { }

    public AdditionModifier(string label, float value) : this(label, 0, value) { }
    
    public AdditionModifier(string label, int priority, float value) : base(label, priority)
    {
        Value = value;
    }
    
    public override float Compute(float input)
    {
        return input + Value;
    }
}
