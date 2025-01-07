
using UnityEngine;

namespace SickLab.Variables
{
    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "Sick Lab/Variables/GameObject Variable")]
    public class GameObjectVariable : BaseVariable<GameObject>
    {
    }

    [System.Serializable]
    public class GameObjectReference : BaseReference<GameObject, GameObjectVariable>
    {
        public GameObjectReference(GameObject value) : base(value)
        {
        }

        public static implicit operator GameObjectReference(GameObject value)
        {
            return new GameObjectReference(value);
        }
    }
}
