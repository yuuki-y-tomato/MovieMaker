using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TL_IN_EVENT : MonoBehaviour
{
    // Start is called before the first frame update

    public PC_Inst_Timeline.Input_Event_st Event;
    private Transform T;
    public string txt;
    
    public int id;

    private Rect R;
    private Rect R1;
    float res;
    public Color ActiveCol;


    private void Awake()
     {
        res=Screen.height/10;
        Event=new PC_Inst_Timeline.Input_Event_st();
        T=GetComponent<Transform>();
        txt=Event.type.ToString();

    
       R=new Rect(res/2,res/2+((res))*id,res,res);
       R1=new Rect(res/2,(res/2+((res))*id)+res/2,res,res);

     }
    // Update is called once per frame
    void Update()
    {
        ActiveCol.a=(Math.Max(TL_TimeLineMng.ctime-Event.start,0.25f));
    }

    public void CreateEventUI()
    {//*INITIALIZER
            
       R=new Rect(res/2,res/2+((res))*id,res,res);
       R1=new Rect(res/2,(res/2+((res))*id)+res/2,res,res);
    }

    private void OnGUI() 
    {
        GUI.color=ActiveCol;   
        GUI.Box(R,Event.type.ToString());
        GUI.Label(R1,"START:\n"+Event.start.ToString("F4"));
    }

}
