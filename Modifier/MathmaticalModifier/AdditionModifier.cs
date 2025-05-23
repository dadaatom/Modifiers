namespace Modifiers
{
    public class AdditionModifier : Modifier
    {
        public float Value { get; }

        public AdditionModifier() : this("", 0, 0)
        {
        }
        
        public AdditionModifier(float value) : this("", 0, value)
        {
        }

        public AdditionModifier(string label, float value) : this(label, 0, value)
        {
        }

        public AdditionModifier(string label, int priority, float value) : base(label, priority)
        {
            Value = value;
        }

        public override float Compute(float input)
        {
            return input + Value;
        }
    }
}
