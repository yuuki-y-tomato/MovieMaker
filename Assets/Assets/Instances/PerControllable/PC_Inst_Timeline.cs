using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PC_Inst_Timeline : MonoBehaviour
{
    /// <summary>
    ///* STORES PARENT ENTITY'S EVENT TIMELINE
    /// </summary>
    //*
    //*
    //* REQ
    //* STORE EVENT
    //* PERFORM ACTION BASED ON EVENT
    //*
    //*

public struct Event_Instance_st
{
//    public int type;

    public PC_Control.Input_st type;

    public float start;
    public float end;
    public Event_Instance_st( PC_Control.Input_st TYPE,float START,float END)
    {
     this.type=   TYPE;
     this.start=START;
     this.end=END;
    }



}

    public bool EListCut=false;

public List<Event_Instance_st> EventList;
    // Start is called before the first frame update
public int eventcount;
    void Start()
    {
        EventList=new List<Event_Instance_st>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
        string st="TYPES : COUNT : "+EventList.Count+"\n";
        int a=0;
        foreach(var b in EventList)
        {  
                st+=a.ToString()+":"+b.type.ToString()+":"+b.start.ToString("F6");
                st+="\n";
                a++;
        }
        Debug.Log(st);

        }

        eventcount=EventList.Count; 
    }

//* USED WHEN MANIPULATIG TIMELINE
static int SortByTime(Event_Instance_st a,Event_Instance_st b)
{
    if(a.start>b.start)
    {
        return 1;
    }
        if(a.start<b.start)
    {
        return -1;
    }
    return 0;
}



/// <summary>
/// * CREATE NEW EVENT AND REMOVE EVENT LATER THAN THAT
/// </summary>
/// <param name="type"></param>
   public void CreateEvent(PC_Control.Input_st type,float t)
    {

//        float t=time;
        int LatestIndex=0;

    //* FIND EVENT AFTER CURRENT TIME

    //* IF NO EVENT IS PRESENT
        if(EventList.Count==0)
        {
             EventList.Add(new Event_Instance_st(type,t,0));
        }
        else
        {//* IF NO OVERWRITE IS REQUIRED
    if(EventList[EventList.Count-1].start<t)
    {
    EventList.Add(new Event_Instance_st(type,t,0));
    }
    else
    {
    for (var i = 1; i < EventList.Count-1;i++)
    {
        if(EventList[i-1].start<t&&EventList[i+1].start>t)
        {
            LatestIndex=i;
        break;

        }
    }
    //*LATEST inDEX is ALWAyS 0
    Debug.Log((EventList.Count-LatestIndex).ToString()+":"+EventList.Count.ToString());
        EventList.RemoveRange(LatestIndex,EventList.Count-LatestIndex);

        
        EventList.Insert(LatestIndex,new Event_Instance_st(type,t,0));

        EListCut=true;

    }


}

    Debug.Log(name+":"+type.ToString()+":"+t.ToString("F6"));

    }

    private int FindLater(float t)
    {
        float latest=1000000;
        int index=0;
        foreach(var b in EventList)
        {
            if(b.start>t&&latest<b.start)
            {
                latest=b.start;
                index=EventList.IndexOf(b);
            }
        }

    if(latest>t)
    {
        return index;
    }
    return -1;

    }





/// <summary>
///* RETUNS NEXT INPUT IN TIMELINE
/// </summary>
/// <returns></returns>
    public Event_Instance_st FindNext()
    {

        //*Return Index Of NEXT EVENT BASED ON TIME

        int index=-1;
        float t=TL_TimeLineMng.ctime;

///* TO PREVENT NULL REFERENCE ON NO ITEM BEING ON THE LIST
if(EventList.Count>0){

        for (var i = 0; i < EventList.Count-1; i++)
            {
                //* IF CURRENT ITEM (i) IS ALREADY OCCURRED AND SUBSEQUENT ONE HASN'T, RETURN INDEX
                if(EventList[i].start<t&&EventList[i+1].start>t)
                    {
                        index=i;
                        break;
                    }
            }

        if(index!=-1){//* IF RETURNED INDEX IS UPDATED
            return EventList[index+1];
        }else
        {
            ///* IN CSAE 2 TIME OVERWRAP
           if(EventList.Count>2){
            if(Math.Abs(EventList[EventList.Count-1].start-EventList[EventList.Count-2].start)<0.01)
                {
                    EventList[EventList.Count-1]=new Event_Instance_st(EventList[EventList.Count-1].type,EventList[EventList.Count-1].start+0.01f,0);                
                    return EventList[EventList.Count-2];

                }
            }
            //* IF NOT THEN LATEST EVENT IS THE LAST EVENT
        return  EventList[EventList.Count-1];

                 //       return new Event_Instance_st(PC_Control.Input_st.NULL,0,0);

        }
    }
    return new Event_Instance_st(PC_Control.Input_st.NULL,0,0);

    }

    public Event_Instance_st FindNext(Event_Instance_st cur)
    {
        if(EventList.Count>1){
        if(EventList.Count>EventList.IndexOf(cur)+1){
              return EventList[EventList.IndexOf(cur)+1];
        }else
        {
            return EventList[EventList.Count-1];
        }
        }
        return GetZero();
    }

    public Event_Instance_st GetZero()
    {
        if(EventList.Count>0)
        {
//            Debug.Log("RETZERO");
            return EventList[0];
        }else
        {
            return new Event_Instance_st(PC_Control.Input_st.NULL,0,0);
        }
    }




}
