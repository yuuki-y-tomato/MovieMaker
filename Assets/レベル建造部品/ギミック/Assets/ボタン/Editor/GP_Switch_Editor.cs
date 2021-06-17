using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GP_Switch))]
public class GP_Switch_Editor : Editor
{
    public enum DisplayCategory
    {
        Components, Objects
    }


    public DisplayCategory categorytoDisplay;
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        categorytoDisplay = (DisplayCategory)EditorGUILayout.EnumPopup("Display", categorytoDisplay);
        EditorGUILayout.Space();

        switch(categorytoDisplay)
        {
            case DisplayCategory.Components:
        DisplayComponents();
            break;
                   case DisplayCategory.Objects:
        DisplayObjects();
            break;

        }
    
    
    
    
    
        serializedObject.ApplyModifiedProperties();

    


    }


    void DisplayComponents()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("LineMatBase"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inactive_sp"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("active_sp"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("active_sp"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("LineBase"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("lines"));


    }

    void DisplayObjects()
    {

        EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("linemul"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Targets"));
  

        
    }

}