using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_EventMng : MonoBehaviour
{
    // Start is called before the first frame update
/// <summary>
/// * RECORD EVENT DISPATCHED BY PC_INPUT
/// * THEN STREAM THEM TO ENTITY MANAGER
/// </summary>
//*
//* REQ
//* LIST OF EVENT INSTANCES
//* FIND ITEM BY PARENT
//* 
//*
//*
//*

    public struct TL_Event
    {
        /// <summary>
        ///* Source of Input
        /// </summary>
        public uint parent;
        
        /// <summary>
        ///* Input Key
        /// </summary>
        public float key;
        public float start;
        public float end;

   public TL_Event(uint id,float key,float start,float end)
    {
        this.parent=id;
        this.key=key;
        this.start=start;
        this.end=end;
    }
    

    }
    private static float time;

    public static List<TL_Event> Eventlist;



    void Start()
    {
     Eventlist=new List<TL_Event>();   
     time = 0;

        EndEvent(GenerateEvent(1,1));
Debug.Log(Eventlist[0].end);
    }

    // Update is called once per frame
    void Update()
    {
        time=Time.time;
    }

    private static int SortbyTime(TL_Event a, TL_Event b)
    {
        if(a.start>b.start)
        {
            return 1;
        }else
        if(a.start<b.start)
        {
            return -1;
        }
    return 0;

    }




   static public int GenerateEvent(uint id,uint input)
    {
        TL_Event buf=new TL_Event(id,input,time,0);

    Eventlist.Add(buf);
    Eventlist.Sort(SortbyTime);
   return  Eventlist.IndexOf(buf);
    }
    
   static public void EndEvent(int EventIndex)
    {
        TL_Event buf=Eventlist[EventIndex];
        buf.end=time;
        Eventlist.Insert(EventIndex,buf);
        Debug.Log(Eventlist[Eventlist.IndexOf(buf)].end);
        Debug.Log(Eventlist[Eventlist.IndexOf(buf)].key);


    }


}
