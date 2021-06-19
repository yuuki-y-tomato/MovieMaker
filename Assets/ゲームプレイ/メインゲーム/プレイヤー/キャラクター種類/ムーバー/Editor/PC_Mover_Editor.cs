using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PC_Type_Moover))]
public class PC_Mover_Editor : Editor
{
    public enum DisplayCategory
    {
        Movement,Components,InputStates
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
                   case DisplayCategory.Movement:
        DisplayMovement();
            break;

                case DisplayCategory.InputStates:
        DisplayInputs();
            break;

        }

    
        serializedObject.ApplyModifiedProperties();


    }

    void DisplayInputs()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Cir"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Squ"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Tri"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("X"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("Left"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Right"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Up"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Down"));

    }

    void DisplayComponents()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cirref"));
    

    }

    void DisplayMovement()
    {

        EditorGUILayout.PropertyField(serializedObject.FindProperty("Drag"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("JumpHeght"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("JumpGravity"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("FallGravity"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("JumpThreshhold"));



        
    }

}