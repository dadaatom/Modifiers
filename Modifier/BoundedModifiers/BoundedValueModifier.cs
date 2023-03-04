using System;

namespace Modifiers
{
    public class BoundedValueModifier : Modifier
    {
        public Bound Bound { get; }
        public float Value { get; }

        public BoundedValueModifier(float value) : this("", 0, Bound.Upper, value)
        {
        }

        public BoundedValueModifier(Bound bound, float value) : this("", 0, bound, value)
        {
        }

        public BoundedValueModifier(string label, Bound bound, float value) : this(label, 0, bound, value)
        {
        }

        public BoundedValueModifier(string label, int priority, Bound bound, float value) : base(label, priority)
        {
            Bound = bound;
            Value = value;
        }

        public override float Compute(float input)
        {
            if (Bound == Bound.Upper)
            {
                return Math.Min(Value, input);
            }

            if (Bound == Bound.Lower)
            {
                return Math.Max(Value, input);
            }

            return input;
        }
    }
}
