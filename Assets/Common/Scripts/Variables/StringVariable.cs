using UnityEngine;

namespace SickLab.Variables
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Sick Lab/Variables/String Variable")]
    public class StringVariable : BaseVariable<string>
    {

    }

    [System.Serializable]
    public class StringReference : BaseReference<string, StringVariable>
    {
        public StringReference(string value) : base(value)
        {
        }

        public static implicit operator StringReference(string value)
        {
            return new StringReference(value);
        }
    }
}