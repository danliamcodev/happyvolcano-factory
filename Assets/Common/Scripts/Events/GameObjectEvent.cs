
using UnityEngine;
using UnityEngine.Events;
using SickLab.Events;

namespace SickLab.Utilities.EventScripts
{
    [CreateAssetMenu(fileName = "GameObjectEvent", menuName = "Sick Lab/Events/GameObject Event")]
    public class GameObjectEvent : BaseGameEvent<GameObject>
    {

    }

    [System.Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject>
    {

    }
}
