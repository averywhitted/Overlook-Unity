using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;


public class SettingsAssetHandler
{
    [OnOpenAsset]
    public static bool OpenEditor(int instanceID, int line)
    {
        SettingsConfigObject obj = EditorUtility.InstanceIDToObject(instanceID) as SettingsConfigObject;
        if (obj != null)
        {
            SettingsEditorWindow.OpenWindow(obj);
        }
        return false;
    }
}

[CustomEditor(typeof(SettingsConfigObject))]
public class SettingsCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Open Settings Editor"))
        {
            SettingsEditorWindow.OpenWindow((SettingsConfigObject)target);
        }
    }
}
