using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationModifier : Modifier
{
    public float Value { get; }
    
    public MultiplicationModifier(float value) : this("", 0, value) { }

    public MultiplicationModifier(string label, float value) : this(label, 0, value) { }
    
    public MultiplicationModifier(string label, int priority, float value) : base(label, priority)
    {
        Value = value;
    }
    
    public override float Compute(float input)
    {
        return input * Value;
    }
}

