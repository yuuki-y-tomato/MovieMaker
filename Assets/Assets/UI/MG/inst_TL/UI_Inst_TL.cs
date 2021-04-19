using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inst_TL : MonoBehaviour
{

    //*
    //* PURPOSE
    //* CREATE AND PLACE ICONS 
    //* BASED ON CORRESPONDING TIMELINES
    //*
    //* 
    //*
    //*
    
    public PC_Inst_Timeline TLRef;
    public int id;
    private int eventcount;

    private List<UI_TL_inst_Icon> IconList;
    static UI_TL_inst_Icon Base;
    void CreateTL(PC_Inst_Timeline tl,int ID)
    {
        Base=FindObjectOfType<UI_TL_inst_Icon>();
        Base.ParentPos=GetComponent<RectTransform>();

        IconList=new List<UI_TL_inst_Icon>();

        TLRef=tl;

        id=ID;
        eventcount=TLRef.EventList.Count;
    }


    void Update()
    {
        if(eventcount==TLRef.EventList.Count+1)
        {
            AppendIcon();
        }
        if(eventcount>TLRef.EventList.Count)
        {
            CutIcon(TLRef.EventList.Count);
        }



    }


    UI_TL_inst_Icon GetIcon(PC_Inst_Timeline.Event_Instance_st ev)
    {
        UI_TL_inst_Icon buf=new UI_TL_inst_Icon();
        buf.Event=ev;
        return buf;
    }

    void AppendIcon()
    {
        IconList.Add(Instantiate(Base));
        UI_TL_inst_Icon buf;
        buf=Instantiate(Base);
        buf.init(TLRef.EventList[eventcount+1]);
        IconList.Add(buf);

    }

    void CutIcon(int NewSize)
    {
        for(int i=NewSize;i<eventcount;i++)
        {
            Object.Destroy(IconList[i]);
        }
        IconList.RemoveRange(NewSize-1,eventcount-NewSize);
        AppendIcon();
        eventcount=NewSize;
    }


}
