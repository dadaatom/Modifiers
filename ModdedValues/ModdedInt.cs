using System;

namespace Modifiers
{
    [Serializable]
    public class ModdedInt : ModdedValue
    {
        public int Value;
        public CastType CastType;

        public ModdedInt() : this(0)
        {
        }

        public ModdedInt(int value, CastType castType = CastType.PostComputations) : this(value,
            new PriorityList<Modifier>(), castType) { }

        public ModdedInt(int value, PriorityList<Modifier> modifiers, CastType castType = CastType.PostComputations) :
            base(modifiers)
        {
            Value = value;
            CastType = castType;
        }

        public int Get()
        {
            float modifiedValue = Value;
            foreach (Modifier modifier in modifiers.GetList())
            {
                if (CastType == CastType.EachComputation)
                {
                    modifiedValue = (int) modifier.Compute(modifiedValue);
                }
                else
                {
                    modifiedValue = modifier.Compute(modifiedValue);
                }
            }

            return (int) modifiedValue;

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
}
