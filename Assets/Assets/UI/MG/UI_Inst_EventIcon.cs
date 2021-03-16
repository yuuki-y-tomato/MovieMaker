using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inst_EventIcon : MonoBehaviour
{
 //*
 //*  REQ
 //* 
 //*  SHOW SET IMAGE AND BE SELECTABLE
 //*
 //*
 //*

  public Texture Image;

    bool set=false;

    int id;
    Rect pos;
    private Animator an;
    void Init()
    {
        an=GetComponent<Animator>();
        pos=new Rect(Screen.width/2,Screen.height/2,100,100);
    }

    // Update is called once per frame
    void Update()
    {
        if(Image!=null&&!set)
        {
           
            set=true;
        }
        AnimationEvent ae;
    }


    private void OnGUI() 
    {
        GUI.Box(pos,Image);

    }


}
