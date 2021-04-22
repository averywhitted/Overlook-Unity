using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class RemotesEditorWindow : ExtendedEditorWindow
{
   Vector2 scrollPos;
   public static void OpenWindow(RemoteConfigObject remotes)
   {
      RemotesEditorWindow window = GetWindow<RemotesEditorWindow>("Remotes Editor");
      window.serializedObject = new SerializedObject(remotes);
   }

   private void OnGUI()
   {
      scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true);
      
      currentProperty = serializedObject.FindProperty("remotes");
      
      EditorGUILayout.BeginHorizontal();

         EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
            DrawSidebar(currentProperty);
            GUILayout.Space(10);
            if (GUILayout.Button("Add Remote"))
            {
               serializedObject.FindProperty("remotes").arraySize++;
            }
         EditorGUILayout.EndVertical();

         EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
            if (selectedProperty != null)
            {
               DrawProperties(selectedProperty, true);
            }
            else
            {
               EditorGUILayout.LabelField("Select a remote to edit.");
            }
         EditorGUILayout.EndVertical();
         
         

      EditorGUILayout.EndHorizontal();
      
      EditorGUILayout.EndScrollView();
        
      Apply();
   }

   
}
