using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Events
{
    [CreateAssetMenu(fileName = "IntEvent", menuName = "Sick Lab/Events/Int Event")]
    public class IntEvent : BaseGameEvent<int>
    {

    }

    [System.Serializable]
    public class IntUnityEvent : UnityEvent<int>
    {

    }
}