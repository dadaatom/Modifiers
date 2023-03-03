﻿
using System;

public class WrappingBoundModifier : BoundedValueModifier
{
    public float WrapValue { get; }

    public WrappingBoundModifier(Bound bound, float value, float wrapValue) : base(bound, value)
    {
        WrapValue = wrapValue;
    }

    public override float Compute(float input)
    {
        if (Bound == Bound.Upper && input > Value)
        {
            return WrapValue;
        }
        
        if (Bound == Bound.Lower && input < Value)
        {
            return WrapValue;
        }
        
        return input;
    }
}
