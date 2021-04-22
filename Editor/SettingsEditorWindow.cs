using UnityEngine;
using UnityEditor;

public class SettingsEditorWindow : ExtendedEditorWindow
{

    public static void OpenWindow(SettingsConfigObject settings)
    {
        SettingsEditorWindow window = GetWindow<SettingsEditorWindow>("Settings Editor");
        window.serializedObject = new SerializedObject(settings);
    }

    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("settings");

        EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
                DrawSidebar(currentProperty);
                GUILayout.Space(10);
                if (GUILayout.Button("Add Setting"))
                {
                    serializedObject.FindProperty("settings").arraySize++;
                }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
                if (selectedProperty != null)
                {
                    DrawProperties(selectedProperty, true);
                }
                else
                {
                    EditorGUILayout.LabelField("Select a setting to edit.");
                }
            EditorGUILayout.EndVertical();
        
        EditorGUILayout.EndHorizontal();
        
        Apply();
    }
}
