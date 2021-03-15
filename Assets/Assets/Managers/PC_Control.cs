
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
        W,Wr,A,Ar,S,Sr,D,Dr,Space,Spacer,Shift,Shiftr,Latest,NULL

    }

    static List<int> InputState;
    private List<int> InputEvent;

    private int id;
    // Start is called before the first frame update

    public static PC_Inst_Timeline TargetTL;

    public float localTime;

    List<Input_st> Ilist;
    bool[] Iactive;
    void Start()
    {
        Iactive=new bool[6];
        TargetTL=FindObjectOfType<PC_Inst_Timeline>();
        InputEvent=new List<int>();
        InputState=new List<int>();
        id=0;
        Ilist=new List<Input_st>();
    }

    // Update is called once per frame

    void Update()
    {

        if(localTime>TL_TimeLineMng.ctime)
        {
            Iactive=new bool[6];
        }

        localTime=TL_TimeLineMng.ctime;
       

        if(Input.GetKey(KeyCode.W))
        {
            if(!Iactive[(int)Input_st.W/2]){
            Ilist.Add(Input_st.W);
            Iactive[(int)Input_st.W/2]=true;
            }
//            TargetTL.CreateEvent(Input_st.W);
        }else
        if(Iactive[(int)Input_st.W/2])
        {
            Ilist.Add(Input_st.Wr);
            Iactive[(int)Input_st.W/2]=false;

           // TargetTL.CreateEvent(Input_st.Wr);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(!Iactive[(int)Input_st.A/2]){

            Ilist.Add(Input_st.A);
            Iactive[(int)Input_st.A/2]=true;
            }
          //  TargetTL.CreateEvent(Input_st.A);
        }
        else
        if(Iactive[(int)Input_st.A/2])
        {
            Ilist.Add(Input_st.Ar);
            Iactive[(int)Input_st.A/2]=false;


         //   TargetTL.CreateEvent(Input_st.Ar);
        }


       if(Input.GetKey(KeyCode.S))
        {
            if(!Iactive[(int)Input_st.S/2]){

            Ilist.Add(Input_st.S);
            Iactive[(int)Input_st.S/2]=true;
            }
        //    TargetTL.CreateEvent(Input_st.S);
        }else
        if(Iactive[(int)Input_st.S/2])
        {
            Iactive[(int)Input_st.S/2]=false;

            Ilist.Add(Input_st.Sr);

        //    TargetTL.CreateEvent(Input_st.Sr);
        }

           if(Input.GetKey(KeyCode.RightArrow))
        {
            if(!Iactive[(int)Input_st.D/2]){

            Iactive[(int)Input_st.D/2]=true;

            Ilist.Add(Input_st.D);
            }
         //   TargetTL.CreateEvent(Input_st.D);
        }else
        if(Iactive[(int)Input_st.D/2])
        {
            Iactive[(int)Input_st.D/2]=false;

            Ilist.Add(Input_st.Dr);

        //    TargetTL.CreateEvent(Input_st.Dr);
        }


        if(Input.GetKey(KeyCode.Space))
        {
            if(!Iactive[(int)Input_st.Space/2]){

            Iactive[(int)Input_st.Space/2]=true;

            Ilist.Add(Input_st.Space);
            }
           // TargetTL.CreateEvent(Input_st.Space);
        }else
        if(Iactive[(int)Input_st.Space/2])
        {
            Iactive[(int)Input_st.Space/2]=false;

            Ilist.Add(Input_st.Spacer);

//            TargetTL.CreateEvent(Input_st.Spacer);
        }


    for (var i = 0; i < Ilist.Count; i++)
    {  
       TargetTL.CreateEvent(Ilist[i],localTime+(0.001f*i));
    }

    Ilist.Clear();
    }
   static public void UpdateTarget(GameObject NEW)
    {
        TargetTL=NEW.GetComponentInParent<PC_Inst_Timeline>();
    }

}
