using System;

namespace Modifiers
{
    [Serializable]
    public class ModdedFloat : ModdedValue
    {
        public float Value;

        public ModdedFloat() : this(0)
        {
        }

        public ModdedFloat(float value) : this(value, new PriorityList<Modifier>())
        {
        }

        public ModdedFloat(float value, PriorityList<Modifier> modifiers) : base(modifiers)
        {
            this.Value = value;
        }

        public float Get()
        {
            float modifiedValue = Value;
            foreach (Modifier modifier in modifiers.GetList())
            {
                modifiedValue = modifier.Compute(modifiedValue);
            }

            return modifiedValue;
        }

        public void Set(float value)
        {
            Value = value;
        }

        public static implicit operator float(ModdedFloat moddedFloat)
        {
            return moddedFloat.Get();
        }

        public static ModdedFloat operator +(ModdedFloat moddedFloat, float value)
        {
            return new ModdedFloat(moddedFloat.Value + value, moddedFloat.modifiers);
        }

        public static ModdedFloat operator -(ModdedFloat moddedFloat, float value)
        {
            return new ModdedFloat(moddedFloat.Value - value, moddedFloat.modifiers);
        }

        public static ModdedFloat operator *(ModdedFloat moddedFloat, float value)
        {
            return new ModdedFloat(moddedFloat.Value * value, moddedFloat.modifiers);
        }

        public static ModdedFloat operator /(ModdedFloat moddedFloat, float value)
        {
            return new ModdedFloat(moddedFloat.Value / value, moddedFloat.modifiers);
        }

        public static ModdedFloat operator %(ModdedFloat moddedFloat, float value)
        {
            return new ModdedFloat(moddedFloat.Value % value, moddedFloat.modifiers);
        }
    }
}
