using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clapper : MonoBehaviour
{
    #region Components
    public GameObject Top;
    public GameObject Bottom;
    public List<TextMesh> Texts;
    Transform Top_T;

    #endregion
    #region Basics


    void Start()
    {

        Top_T = Top.GetComponent<Transform>();

        Texts[0].text = "Start";
    }

    // Update is called once per frame
    void Update()
    {
        GamePlay();
        if (Input.GetKey(KeyCode.P))
        {
            rot = smin(rot + rotrate, rotmax, smooth);
            Debug.Log(rot);
        }
        else
        {
            rot -= rotrate * 4.0f;
            rot = Math.Max(rot, 0);
        }

        Top_T.rotation = Quaternion.Euler(0, 0, -rot);

    }

    #endregion

    #region States
   
    #region  Ready
    #region Variables
    private float rot;
    public float rotrate;
    public float rotmax;
    public float smooth;
    #endregion
    void Ready()
    {

    }
    #endregion
    
    #region gameplay
    ///*
    ///*    REQ
    ///*    SLIDER,TIMER
    ///*
    ///*
    /// 
    #region Var
    public Material Mat;
    public float SliderRate=1.0f;
    #endregion
    void GamePlay()
    {
        GP_Timer();

        Texts[0].text="制限時間:";
        Texts[1].text=(TL_TimeLineMng.Max_acc-TL_TimeLineMng.ctime).ToString();

        
    }

    void GP_Timer()
    {
         Mat.SetFloat("_time",TL_TimeLineMng.ctime*SliderRate);
        Mat.SetFloat("_Slider",TL_TimeLineMng.ctime/TL_TimeLineMng.Max_acc);
    }

    #endregion
    
    #endregion
    #region Utils
    public void UpdateGamestate(int id)
    {

        switch (id)
        {
            case 0:

                break;

        }
    }

    float smin(float val, float lim, float smooth)
    {

        float buf;
        buf = Math.Max(smooth - Math.Abs(val - lim), 0) / smooth;

        return Math.Min(val, lim) - buf * buf * smooth * 0.25f;


    }
    #endregion

}
