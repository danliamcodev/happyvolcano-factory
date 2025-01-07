using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Events
{
    [CreateAssetMenu(fileName = "VoidEvent", menuName = "Sick Lab/Events/Void Event")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise()
        {
            Raise(new Void());
        }
    }

    [System.Serializable]
    public class VoidUnityEvent : UnityEvent<Void>
    {
        public void InvokeVoid()
        {
            Invoke(new Void());
        }
    }

    [System.Serializable] public struct Void { }
}