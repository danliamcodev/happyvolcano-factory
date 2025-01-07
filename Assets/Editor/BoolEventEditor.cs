
using UnityEngine;
using UnityEditor;
using SickLab.Events;

namespace SickLab.Utilities.EventScripts
{
    [CustomEditor(typeof(BoolEvent))]
    public class BoolEventEditor : BaseEventEditor<bool, BoolEvent>
    {

    }
}
