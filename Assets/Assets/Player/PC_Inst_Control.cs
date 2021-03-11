using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Inst_Control : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// * DISPATCH LIST OF CURRENTLY ACTIVE INPUT TO CHILD
    /// </summary>
    //*
    //* REQ
    //* 
    //* PERFORM START AND END EVENTS
    //*
    //*
    //*


/// <summary>
///* LIST OF INPUTS THAT CURRENTLY ACTIVE
/// </summary>
    public int[] Input_States;
     private PC_Inst_Timeline.Event_Instance_st NextInput;


   private PC_Inst_Timeline Timeline_Ref;
    //*INTERFACE TO INSTANCE TIMELINE
    
    void Start()
    {
    Input_States=new int[7];
    Timeline_Ref=GetComponentInParent<PC_Inst_Timeline>();
    NextInput=new PC_Inst_Timeline.Event_Instance_st();
    }



    void Update()
    {
        if(NextInput.type==PC_Control.Input_st.NULL)
        {
            NextInput=Timeline_Ref.GetZero();
        }
UpdateInputStates();

    }

    void UpdateInputStates()
    {

        //*CHARNGES INPUT STATES BASED ON TIMELINE OCCURENCES

//*if next event occured
    if(TL_TimeLineMng.ctime>=NextInput.start&&NextInput.type!=PC_Control.Input_st.NULL)
    {

        //*PRESSED 1 , RELEASE EVENT 2, INACTIVE 0

        Input_States[(int)NextInput.type/2]=(int)NextInput.type%2;
        //*Get next input event
        NextInput=Timeline_Ref.FindNext(NextInput);
    }

    }



}
