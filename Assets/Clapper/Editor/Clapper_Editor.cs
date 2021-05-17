using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Clapper))]
public class Clapper_Editor : Editor
{
    public enum DisplayCategory
    {
        Components, Choice, Ready, GP, Replay
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
                   case DisplayCategory.Ready:
        DisplayReady();
            break;
            case DisplayCategory.GP:
             DisplayGP();
            break;
        }
    
    
    
    
    
        serializedObject.ApplyModifiedProperties();

    


    }


    void DisplayComponents()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Top"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Bottom"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Texts"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Mat"));


    }

    void DisplayReady()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rotrate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rotmax"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("smooth"));


        
    }
void DisplayGP()
{
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SliderRate"));


}
}