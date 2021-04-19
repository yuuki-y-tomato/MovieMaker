using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_StateMng : MonoBehaviour
{

    //*
    //* PURPOSE
    //*
    //* -MANAGE CURRENT GAME STATE
    //* SUCH AS PAUSING MIAN GAME DURING TIMELINE EDITING
    //*
    //*
    //*

    public GameObject TL_cnt;
    public RectTransform DefPos;
    private Animator Animator;

    public int state;

    void Start()
    {
        state=0;
        Animator=TL_cnt.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {
            RaiseMenu();
        }
            if(Input.GetKey(KeyCode.I))
        {
            LowerMenu();
        }
    
    }

    void RaiseMenu()
    {
        Animator.Play("UP",0);
    }
void LowerMenu()
    {
        Animator.Play("DOWN",0);
    }
    


}
