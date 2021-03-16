using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_Manager : MonoBehaviour
{

    //*
    //* PURPOSE
    //* =INTERFACE TO EVERY TIMELINES
    //*
    //* REQ
    //*
    //* =TAKE ALL TIMELINES
    //*
    //*
    //*
    
  public static  List<PC_Inst_Timeline> TimelineList;
    // Start is called before the first frame update
    void Start()
    {
        TimelineList=new List<PC_Inst_Timeline>();
        TimelineList.AddRange(FindObjectsOfType<PC_Inst_Timeline>());
    }

}
