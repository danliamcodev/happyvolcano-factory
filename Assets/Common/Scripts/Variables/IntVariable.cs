using UnityEngine;

namespace SickLab.Variables
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Sick Lab/Variables/Int Variable")]
    public class IntVariable : BaseVariable<int>
    {
        public void ApplyChange(int p_amount)
        {
            int previousValue = value;
            _value += p_amount;
            ValueUpdated?.Invoke(value);
            ValueUpdatedWithPrevious?.Invoke(previousValue, value);
        }

        public void ApplyChange(IntVariable p_amount)
        {
            ApplyChange(p_amount.value);
        }
    }

    [System.Serializable]
    public class IntReference : BaseReference<int, IntVariable>
    {
        public IntReference(int value) : base(value)
        {
        }

        public static implicit operator IntReference(int value)
        {
            return new IntReference(value);
        }
    }
}