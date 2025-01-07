using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Events
{
    [CreateAssetMenu(fileName = "StringEvent", menuName = "Sick Lab/Events/String Event")]
    public class StringEvent : BaseGameEvent<string>
    {

    }

    [System.Serializable]
    public class StringUnityEvent : UnityEvent<string>
    {

    }
}