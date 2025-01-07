using UnityEditor;

namespace SickLab.Events
{
    [CustomEditor(typeof(StringEvent))]
    public class StringEventEditor : BaseEventEditor<string, StringEvent>
    {

    }
}