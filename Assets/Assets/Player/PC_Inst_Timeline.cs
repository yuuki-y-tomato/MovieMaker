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


private List<Event_Instance_st> EventList;
    // Start is called before the first frame update

    void Start()
    {
        EventList=new List<Event_Instance_st>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
        string st="TYPES\n";
        int a=0;
        foreach(var b in EventList)
        {  
                st+=a.ToString()+":"+b.type.ToString()+":"+b.start.ToString("F6");
                st+="\n";
                a++;
        }
        Debug.Log(st);

        }


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
   public void CreateEvent(PC_Control.Input_st type)
    {
        EventList.Sort(SortByTime);

        float t=TL_TimeLineMng.ctime;
        int LatestIndex=0;


        foreach(var b in EventList)
        {
            if(b.start<t)//*occured later than new instance
            {
       LatestIndex=EventList.IndexOf(b);
       break;
            }
        }
        //*REMOVE ALL FURTHER INSTANCES
//    EventList.RemoveRange(LatestIndex,EventList.Count-LatestIndex);



    {
    int a=FindLater(t);
        if(a!=-1)
        {

        }
    }



        //*APPEND NEW EVENT
    EventList.Add(new Event_Instance_st(type,t,0));


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
/*
        foreach(var b in EventList)
        {
            if(b.start<t)
            {
             index=EventList.IndexOf(b);
            break;
            }
        }*/
        //*COUNTS UP FROM START TO END
        for (var i = 0; i < EventList.Count; i++)
        {
            //*IF CURRENT OCCURED LATER THAN TIME
            if(t<EventList[i].start)//*POINTS TO NEXT EVENT
            {
                index=i-1;
                break;
            }
            
        }


        return EventList[index];
    }

    public Event_Instance_st FindNext(Event_Instance_st cur)
    {
        if(EventList.Count>1){
              return EventList[EventList.IndexOf(cur)+1];
        }else
        {
            return new Event_Instance_st(PC_Control.Input_st.NULL,0,0);
        }

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
