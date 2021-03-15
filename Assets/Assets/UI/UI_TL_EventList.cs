using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TL_EventList : MonoBehaviour
{

//* 
//*     CHECK CURRENT TARGET TL AND CREATE POPUP OF EVENTS
//*
//*
//*
//*
//*
//*

//* C___ Current TARGETED TIMELINE
    private PC_Inst_Timeline CTarget;
    public List<PC_Inst_Timeline.Event_Instance_st> CEventList;

//* ISNTANCES OF UI POPUP
    public UI_TL_IN_EVENT[] EventUIList;
//* INSTANTIATION LMAB
    private UI_TL_IN_EVENT EventBase;
    //* CURRENT EVENT LIST SIZE
    private int Einst_count;
    //* POPUP COLOR
    public Color ActiveColor;

    // Start is called before the first frame update
    void Start()
    {
        EventBase=FindObjectOfType<UI_TL_IN_EVENT>();
        EventBase.enabled=false;
        EventUIList=new UI_TL_IN_EVENT[10];
    for (var i = 0; i < EventUIList.Length; i++)
     {
         //* CREATE INSTANCES OF EVENT POPUP
         EventUIList[i]=Instantiate<UI_TL_IN_EVENT>(EventBase);
          EventUIList[i].enabled=false;

     }
    }


    void init()
    {
        //* SEPARATE INITIALIZATION FOR WHEN NO LIST ISNT SELECTED
        CTarget=PC_Control.TargetTL;
        CEventList=PC_Control.TargetTL.EventList;
        Einst_count=Math.Min(CEventList.Count,10);

    }

    // Update is called once per frame
    void Update()
    {

        if(CEventList==null|| CTarget!=PC_Control.TargetTL)
        {
            init();
            Updatelist();

        }
    
    //*WHEN EVENT REMOVED/ADDED
        if(Einst_count!=CEventList.Count)
        {
            Einst_count=Math.Min(CEventList.Count,10);

            Updatelist();
                    
        }

      
    
    }

    void Updatelist()
    {
     for (var i = 0; i < Einst_count; i++)
     {
         EventUIList[i].Event=CEventList[i];
         EventUIList[i].id=i;
         EventUIList[i].enabled=true;
         EventUIList[i].ActiveCol=ActiveColor;
         EventUIList[i].CreateEventUI();

        
     }
     for (var i = Einst_count; i < 10; i++)
     {
         EventUIList[i].enabled=false;
     }
    }
}
