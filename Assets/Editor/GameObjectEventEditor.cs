
using UnityEngine;
using UnityEditor;
using SickLab.Events;

namespace SickLab.Utilities.EventScripts
{
    [CustomEditor(typeof(GameObjectEvent))]
    public class GameObjectEventEditor : BaseEventEditor<GameObject, GameObjectEvent>
    {

    }
}
