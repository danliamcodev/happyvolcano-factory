using UnityEngine;

namespace SickLab.Variables
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Sick Lab/Variables/Float Variable")]
    public class FloatVariable : BaseVariable<float>
    {
        public void ApplyChange(float p_amount)
        {
            float previousValue = value;
            _value += p_amount;
            ValueUpdated?.Invoke(value);
            ValueUpdatedWithPrevious?.Invoke(previousValue, value);
        }

        public void ApplyChange(FloatVariable p_amount)
        {
            ApplyChange(p_amount.value);
        }
    }

    [System.Serializable]
    public class FloatReference: BaseReference<float, FloatVariable>
    {
        public FloatReference(float value) : base(value)
        {
        }
    }
}