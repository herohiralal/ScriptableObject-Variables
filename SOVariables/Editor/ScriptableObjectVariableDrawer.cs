using System;
using UnityEngine;
using UnityEditor;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [CustomPropertyDrawer(typeof(SOVariable), true)]
    public class ScriptableObjectVariableDrawer : PropertyDrawer
    {
        private static readonly string NAMESPACE_FOR_SOVARIABLES = typeof(SOVariable).Namespace;
        private static readonly string ASSEMBLY_FOR_SOVARIABLES = typeof(SOVariable).Assembly.FullName;

        private const string VARIABLE_VALUE_NAME = "Value";

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = 21;

            if (property.objectReferenceValue != null)
            {
                var serializedReference = new SerializedObject(property.objectReferenceValue);
                height += EditorGUI.GetPropertyHeight(serializedReference.FindProperty(VARIABLE_VALUE_NAME)) + 2;
            }

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var referenceRect = new Rect(position.x, position.y, position.width, 21);
            var mainRect = EditorGUI.PrefixLabel(referenceRect, label);
            mainRect.height = 19;

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            if (property.objectReferenceValue == null)
            {
                var buttonRect = new Rect(mainRect.x, mainRect.y, 19, 19);
                mainRect.x += 21;
                mainRect.width -= 21;
                if (GUI.Button(buttonRect, "+"))
                {
                    CreateVariable(property);
                }
            }
            else
            {
                var serializedReference = new SerializedObject(property.objectReferenceValue);
                var serializedValue = serializedReference.FindProperty(VARIABLE_VALUE_NAME);
                
                var valueRect = new Rect(mainRect.x - 21, position.y + 21,
                    mainRect.width + 21, EditorGUI.GetPropertyHeight(serializedValue));

                EditorGUI.BeginChangeCheck();
                EditorGUI.PropertyField(valueRect, serializedValue, GUIContent.none);
                if (EditorGUI.EndChangeCheck()) serializedReference.ApplyModifiedProperties();
            }

            EditorGUI.PropertyField(mainRect, property, GUIContent.none);

            EditorGUI.indentLevel = indent;
        }

        private static void CreateVariable(SerializedProperty property)
        {
            string path = EditorUtility.SaveFilePanelInProject("Save File", "New Object",
                "asset", "Save file to...");

            if (!string.IsNullOrEmpty(path))
            {
                string variablepath = NAMESPACE_FOR_SOVARIABLES + "." +
                              property.type.Replace("PPtr<$", "").Replace(">", "")
                              + ", " + ASSEMBLY_FOR_SOVARIABLES;
                
                property.objectReferenceValue = ScriptableObject.CreateInstance(Type.GetType(variablepath));
                AssetDatabase.CreateAsset(property.objectReferenceValue, path);
            }
        }
    }
}