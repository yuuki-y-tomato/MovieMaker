using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Turret_Control))]
public class Turret_Control_Editor : Editor
{
    public enum DisplayCategory
    {
        性能, コンポーネント
    }

    public DisplayCategory categorytoDisplay;
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        categorytoDisplay = (DisplayCategory)EditorGUILayout.EnumPopup("Display", categorytoDisplay);
        EditorGUILayout.Space();

        switch (categorytoDisplay)
        {
            case DisplayCategory.性能:
                DisplayVar();
                break;
            case DisplayCategory.コンポーネント:
                DisplayComponents();
                break;


        }





        serializedObject.ApplyModifiedProperties();




    }


    void DisplayVar()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("DownTime"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Speed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dir"));



    }

    void DisplayComponents()
    {

        EditorGUILayout.PropertyField(serializedObject.FindProperty("Meter"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Base"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ac"));



    }

}