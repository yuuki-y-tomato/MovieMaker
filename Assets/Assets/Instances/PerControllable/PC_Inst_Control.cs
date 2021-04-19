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
    //* SEND INPUT TO CONTROLLABLES
    //*
    //*


/// <summary>
///* LIST OF INPUTS THAT CURRENTLY ACTIVE
/// </summary>
    public int[] Input_States;
     public PC_Inst_Timeline.Event_Instance_st NextInput;

    private float LocalTimer;
   private PC_Inst_Timeline Timeline_Ref;
    //*INTERFACE TO INSTANCE TIMELINE

    private Vector3 DefPos;
    private PC_Base ActorRef;
    void Start()
    {
        ActorRef=GetComponent<PC_Base>();

    Input_States=new int[7];
    for (var i = 0; i < Input_States.Length; i++)
    {
        Input_States[i]=1;
    }
    Timeline_Ref=GetComponentInParent<PC_Inst_Timeline>();
    NextInput=new PC_Inst_Timeline.Event_Instance_st();
    NextInput.type=PC_Control.Input_st.NULL;
    DefPos=GetComponent<Transform>().position;
    }
        


    void Update()
    {
    
//    Rigidbody2D b;
        //* ON RESET
        
        if(LocalTimer>TL_TimeLineMng.ctime)
{
    //*RESET POSITION
    GetComponent<Transform>().position=DefPos;


    ClearInput();
    //* REINITIALIZE INPUT STATES



        //*GET THE FIRST EVENT RECORDED
            NextInput=Timeline_Ref.GetZero();
}

        LocalTimer=TL_TimeLineMng.ctime;


        if(LocalTimer<0.0001f)
         {
        ClearInput();
        }   

        if(Timeline_Ref.EListCut)
        {
            ClearInput();
            Timeline_Ref.EListCut=false;
        }


//*If NO EVENT FOUND
        if(NextInput.type==PC_Control.Input_st.NULL)
        {
            NextInput=Timeline_Ref.GetZero();
        }
//*IF EVENT START IS REACHED
if(NextInput.start<LocalTimer)
{
    UpdateInputStates();
}



    }

    void UpdateInputStates()
    {
    
        //*PRESSED 1 , RELEASE EVENT 2, INACTIVE 0

 
 //       Input_States[(int)NextInput.type/2]=((int)NextInput.type%2);
        ActorRef.DispatchEvent(((int)NextInput.type));
        //*Get next input event
        NextInput=Timeline_Ref.FindNext(NextInput);

    }

  public  void ClearInput()
    {
        for (var i = 0; i < Input_States.Length; i++)
    {
        Input_States[i]=1;
    }
    }



}
