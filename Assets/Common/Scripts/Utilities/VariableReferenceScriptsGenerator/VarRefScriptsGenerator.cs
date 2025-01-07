using System.IO;
using UnityEngine;
using UnityEditor;

namespace SickLab.Utilities.VariableReferenceScripts
{
    [CreateAssetMenu(fileName = "VarRefScriptsGenerator", menuName = "Sick Lab/Utility/Variable Reference Scripts Generator")]
    public class VarRefScriptsGenerator : ScriptableObject
    {
#if UNITY_EDITOR
        [Header("References")]
        [SerializeField] DefaultAsset _variablesFolder;
        [SerializeField] DefaultAsset _editorsFolder;
        [SerializeField] MonoScript _variableReferenceTemplate;
        [SerializeField] MonoScript _variableReferenceDrawerTemplate;
#endif

        [Header("Variables")]
        [SerializeField] string _variableType;
        public void GenerateScripts()
        {
#if UNITY_EDITOR
            GenerateVariableReferenceScript();
            GenerateEventEditorScript();
            AssetDatabase.Refresh();
#endif
        }

        private void GenerateVariableReferenceScript()
        {
#if UNITY_EDITOR
            string scriptName = $"{_variableType}Variable";
            string scriptText = _variableReferenceTemplate.text;

            scriptText = (RemoveCommentTokens(scriptText));

            // Replace the placeholders with the actual event type
            scriptText = scriptText.Replace("TemplateVariable", _variableType);

            string folderPath = AssetDatabase.GetAssetPath(_variablesFolder);
            string scriptPath = Path.Combine(folderPath, scriptName + ".cs");

            File.WriteAllText(scriptPath, scriptText);
#endif
        }

        private void GenerateEventEditorScript()
        {
#if UNITY_EDITOR
            string scriptName = $"{_variableType}ReferenceDrawer";
            string scriptText = _variableReferenceDrawerTemplate.text;

            scriptText = (RemoveCommentTokens(scriptText));

            // Replace the placeholders with the actual event type
            scriptText = scriptText.Replace("TemplateVariable", _variableType);

            string folderPath = AssetDatabase.GetAssetPath(_editorsFolder);
            string scriptPath = Path.Combine(folderPath, scriptName + ".cs");

            File.WriteAllText(scriptPath, scriptText);
#endif
        }

        private string RemoveCommentTokens(string p_string)
        {
            string modifiedString = "";
            // Check if the original string has at least 4 characters
            if (p_string.Length >= 4)
            {
                modifiedString = p_string.Substring(2, p_string.Length - 4);
            }
            return modifiedString;
        }
    }
}