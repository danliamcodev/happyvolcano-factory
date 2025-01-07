using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Events
{
    [CreateAssetMenu(fileName = "FloatEvent", menuName = "Sick Lab/Events/Float Event")]
    public class FloatEvent : BaseGameEvent<float>
    {

    }

    [System.Serializable]
    public class FloatUnityEvent : UnityEvent<float>
    {

    }
}