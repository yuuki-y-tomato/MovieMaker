using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TL_IconPlacer : MonoBehaviour
{
    // Start is called before the first frame update

    //*
    //* PURPOSE
    //* SIT ABOVE ALL TIMELINE UI
    //* FIND ALL TIMELINES
    //* CREATE INSTANCES OF TIMELINE UI,
    //* THEN ASSIGN CORRESPONDING TLINSTANCES
    //* AND PLACE IT TO RIGHT POSITION
    //* 


    PC_Inst_Timeline TLRef;

    void Start()
    {
        TLRef=PC_Control.TargetTL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
