using UnityEditor;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [CustomPropertyDrawer(typeof(SOVariableReference), true)]
    public class ScriptableObjectVariableReferenceDrawer : PropertyDrawer
    {
        private const string USE_CONSTANT_PROPERTY_NAME = "useConstant";
        private const string CONSTANT_VALUE_PROPERTY_NAME = "constant";
        private const string VARIABLE_VALUE_PROPERTY_NAME = "variable";
        private static readonly string[] POPUP_OPTIONS = { "Use Constant", "Use Variable" };
        private GUIStyle popupStyle;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = 21;

            if (!property.FindPropertyRelative(USE_CONSTANT_PROPERTY_NAME).boolValue 
                && property.FindPropertyRelative(VARIABLE_VALUE_PROPERTY_NAME).objectReferenceValue != null)
            {
                height += 21;
            }

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions")) {imagePosition = ImagePosition.ImageOnly};
            }
            
            var useConstant = property.FindPropertyRelative(USE_CONSTANT_PROPERTY_NAME);
            var constantValue = property.FindPropertyRelative(CONSTANT_VALUE_PROPERTY_NAME);
            var variable = property.FindPropertyRelative(VARIABLE_VALUE_PROPERTY_NAME);
            
            var mainRect = new Rect(position.x, position.y, position.width, 19);

            mainRect = EditorGUI.PrefixLabel(mainRect, label);
            var buttonRect = new Rect(mainRect.x, mainRect.y, 19, mainRect.height);
            mainRect.x += 21;
            mainRect.width -= 21;

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, POPUP_OPTIONS, popupStyle);
            useConstant.boolValue = result == 0;

            if (!useConstant.boolValue)
            {
                mainRect.height = 42;
            }
            
            EditorGUI.PropertyField(mainRect, useConstant.boolValue ? constantValue : variable, GUIContent.none);
            
            EditorGUI.indentLevel = indent;
        }
    }
}