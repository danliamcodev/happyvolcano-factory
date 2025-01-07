using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SickLab.Variables
{
    public abstract class BaseReferenceDrawer: PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] _popupOptions =
            { "Use Constant", "Use Variable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle _popupStyle;

        public override void OnGUI(Rect p_position, SerializedProperty p_property, GUIContent p_label)
        {
            if (_popupStyle == null)
            {
                _popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _popupStyle.imagePosition = ImagePosition.ImageOnly;
            }


            p_label = EditorGUI.BeginProperty(p_position, p_label, p_property);
            p_position = EditorGUI.PrefixLabel(p_position, p_label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty useConstant = p_property.FindPropertyRelative("_useConstant");
            SerializedProperty constantValue = p_property.FindPropertyRelative("_constantValue");
            SerializedProperty variable = p_property.FindPropertyRelative("_variable");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(p_position);
            buttonRect.yMin += _popupStyle.margin.top;
            buttonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right;
            p_position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, _popupOptions, _popupStyle);

            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(p_position,
                useConstant.boolValue ? constantValue : variable,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                p_property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}

