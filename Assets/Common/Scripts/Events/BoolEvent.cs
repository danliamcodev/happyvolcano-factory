
using UnityEngine;
using UnityEngine.Events;
using SickLab.Events;

namespace SickLab.Utilities.EventScripts
{
    [CreateAssetMenu(fileName = "BoolEvent", menuName = "Sick Lab/Events/bool Event")]
    public class BoolEvent : BaseGameEvent<bool>
    {

    }

    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {

    }
}
