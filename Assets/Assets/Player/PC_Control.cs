
using System.Collections.Generic;
using UnityEngine;

public class PC_Control : MonoBehaviour
{
/// <summary>
///* HANDLES ALL INPUT TO THE ENTITY
///* THEN SEND THEM TO THE TIMELINE
/// </summary>

//* REQUIREMENT 
//* ADD INPUT TO TIMELINE
//* 
//*
//*
//*
    public enum Input_st
    {
        W,Wr,A,Ar,S,Sr,D,Dr,Space,Spacer,Shift,Shiftr,NULL

    }

    static List<int> InputState;
    private List<int> InputEvent;

    private int id;
    // Start is called before the first frame update

    private static PC_Inst_Timeline TargetTL;



    void Start()
    {
        TargetTL=FindObjectOfType<PC_Inst_Timeline>();
        InputEvent=new List<int>();
        InputState=new List<int>();
        id=0;
    }

    // Update is called once per frame

    void Update()
    {


        if(Input.GetKeyDown(KeyCode.W))
        {
            TargetTL.CreateEvent(Input_st.W);
        }
        
        if(Input.GetKeyUp(KeyCode.W))
        {
            TargetTL.CreateEvent(Input_st.Wr);
        }

    }
   static public void UpdateTarget(GameObject NEW)
    {
        TargetTL=NEW.GetComponentInParent<PC_Inst_Timeline>();
    }

}
