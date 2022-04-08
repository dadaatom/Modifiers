using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedValueModifier : Modifier
{
    public Bound Bound { get; }
    public float Value { get; }
    
    public BoundedValueModifier(float value) : this("", 0, Bound.Upper, value) { }
    
    public BoundedValueModifier(Bound bound, float value) : this("", 0, bound, value) { }

    public BoundedValueModifier(string label, Bound bound, float value) : this(label, 0, bound, value) { }
    
    public BoundedValueModifier(string label, int priority, Bound bound, float value) : base(label, priority)
    {
        Bound = bound;
        Value = value;
    }
    
    public override float Compute(float input)
    {

        if (Bound == Bound.Upper && input > Value)
        {
            return Value;
        }
        
        if (Bound == Bound.Lower && input < Value)
        {
            return Value;
        }
        
        return input;
    }
}
