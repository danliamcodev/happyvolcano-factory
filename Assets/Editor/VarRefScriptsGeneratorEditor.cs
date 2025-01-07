using UnityEditor;
using UnityEngine;

namespace SickLab.Utilities.VariableReferenceScripts
{
    [CustomEditor(typeof(VarRefScriptsGenerator))]
    public class VarRefScriptsGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Generate Scripts"))
            {
                VarRefScriptsGenerator generator = (VarRefScriptsGenerator)target;
                generator.GenerateScripts();
            }
        }
    }
}

