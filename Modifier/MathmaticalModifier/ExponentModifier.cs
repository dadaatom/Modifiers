using System;

namespace Modifiers
{
    public class ExponentModifier : Modifier
    {
        public float Value { get; }

        public ExponentModifier(float value) : this("", 0, value)
        {
        }

        public ExponentModifier(string label, float value) : this(label, 0, value)
        {
        }

        public ExponentModifier(string label, int priority, float value) : base(label, priority)
        {
            Value = value;
        }

        public override float Compute(float input)
        {
            return (float) Math.Pow(input, Value);
        }
    }
}
