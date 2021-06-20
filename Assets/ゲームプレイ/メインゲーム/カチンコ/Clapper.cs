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
    public Transform ReadyParent;
    public Transform GPParent;

    private MG_StateManager stateManagerref;

    Transform Top_T;

    #endregion
    #region Basics

    public Transform T;


    void Start()
    {
        stateManagerref = FindObjectOfType<MG_StateManager>();
        SliderMat.SetFloat("_Slider", 0);
        T = GetComponent<Transform>();
        Top_T = Top.GetComponent<Transform>();

        //Texts[0].text = "Start";
        prevstate = MG_StateManager.States.Ready;
        SetContents(prevstate);
    }

    MG_StateManager.States prevstate;

    void Update()
    {

        if (prevstate != MG_StateManager.state)
        {
            prevstate = MG_StateManager.state;
            SetContents(prevstate);
        }


        switch (prevstate)
        {
            case MG_StateManager.States.Ready:
                Ready();
                break;

            case MG_StateManager.States.Gameplay:
                GamePlay();
                break;
        }
        SliderMat.SetFloat("_Slider", TL_TimeLineMng.ctime / TL_TimeLineMng.GetTimelim());

    }

    void CLearContents()
    {
        Setv(ReadyParent, 10, 2);
        Setv(GPParent, 10, 2);


    }


    public float number;
    void SetContents(MG_StateManager.States tgt)
    {
        CLearContents();
        switch (tgt)
        {
            case MG_StateManager.States.Ready:
                Setv(ReadyParent, 0, 2);
                break;
            case MG_StateManager.States.Gameplay:
                Setv(GPParent, 0, 2);
                break;
        }
    }

    #endregion

    #region States

    #region  Ready

    #region Variables

    [Header("Components")]
    public TextMesh TakeCount;
    public TextMesh SceneCount;


    [Header("Var")]
    public float rotrate;
    public float rotmax;
    public float smooth;
    private float rot;

    [Header("Position")]

    public float ReadySize;
    public Vector3 ReadyPos;

    private bool set;
    #endregion
    void Ready()
    {

        TakeCount.text = "Take " + (stateManagerref.Takes + 1).ToString();
        SceneCount.text = "Scene " + stateManagerref.Actors + "/" + (stateManagerref.CurrentActor + 1).ToString();

        if (Input.GetKey(KeyCode.P))
        {
            rot = smin(rot + rotrate, rotmax, smooth);
            //   Debug.Log(rot);

        }
        else
        {
            rot -= rotrate * 4.0f;
            rot = Math.Max(rot, 0);
        }
        if (rot > rotmax / 4)
        {
            set = true;
        }
        if (rot < 0.05f && set && MG_StateManager.state == MG_StateManager.States.Ready)
        {
            Debug.Log("cir");
            set = false;
            FindObjectOfType<CAM_Gameplay>().Ready_to_GP();
            TL_TimeLineMng.run(true);
        }


        //   T.localScale+=lerp(T.localScale,ReadySize,Speed);
        //   T.position+=lerp(T.position,ReadyPos,Speed);
        if (Input.GetKeyDown(KeyCode.K))
        {

            MG_StateManager.state = MG_StateManager.States.Gameplay;
        }
        Top_T.rotation = Quaternion.Euler(0, 0, -rot);

    }
    void readyinit()
    {
        set = false;

    }
    #endregion

    #region gameplay




    #region Var
    [Header("Components")]
    public TextMesh TimerText;
    public Material SliderMat;
    private Material Slidermatinst;
    public float SliderRate = 1.0f;
    #endregion
    
    void GamePlay()
    {
        GP_UpdateSlider();

        TimerText.text = ((int)(TL_TimeLineMng.GetTimelim() - TL_TimeLineMng.ctime)).ToString();

    }

    void GP_UpdateSlider()
    {
        SliderMat.SetFloat("_time", TL_TimeLineMng.ctime * SliderRate);
        // SliderMat.SetFloat("_Slider", TL_TimeLineMng.ctime / TL_TimeLineMng.Max_acc);
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

    public static float lerp(float v, float tgt, float rate)
    {
        return Math.Min(tgt - v, 1.0f) * rate;
    }
    public static Vector3 lerp(Vector3 v, Vector3 tgt, float rate)
    {
        return (tgt - v).normalized * rate;
    }


    public static void Setv(Transform v, float value, int index)
    {
        Vector3 buf = v.localPosition;
        switch (index)
        {
            case 0:
                v.localPosition = new Vector3(value, buf.y, buf.z);
                break;
            case 1:
                v.localPosition = new Vector3(buf.x, value, buf.z);
                break;
            case 2:
                v.localPosition = new Vector3(buf.x, buf.y, value);
                break;
        }
        Debug.Log(v.position.ToString());


    }

    #endregion




}
