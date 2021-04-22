using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;



public class RemotesAssetHandler
{
    [OnOpenAsset]
    public static bool OpenEditor(int instanceID, int line)
    {
        RemoteConfigObject obj = EditorUtility.InstanceIDToObject(instanceID) as RemoteConfigObject;
        if (obj != null)
        {
            RemotesEditorWindow.OpenWindow(obj);
        }
        return false;
    }
}

[CustomEditor(typeof(RemoteConfigObject))]
public class RemotesCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Open Remotes Editor"))
        {
            RemotesEditorWindow.OpenWindow((RemoteConfigObject)target);
        }
    }
}
