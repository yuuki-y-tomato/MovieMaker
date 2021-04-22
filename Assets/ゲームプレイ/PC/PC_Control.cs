
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 今操作しているキャラクターのインプット記録に入力を送る
/// </summary>
public class PC_Control : MonoBehaviour
{
/// <summary>
/// インプット種類
///  #:ボタン押し　#r:ボタン放し
/// </summary>
    public enum Input_st
    {
        W,Wr,A,Ar,S,Sr,D,Dr,X,Xr,Tri,Trir,Square,Squarer,Circle,Circler,Latest,NULL

    }
/// <summary>
/// 現在操作しているキャラクターのインプット記録リスト
/// </summary>
    public static PC_Inst_Timeline TargetTL;
/// <summary>
/// タイマー.  時間がリセットされた時初期化するため
/// </summary>
    public float localTime;

/// <summary>
///　入力状態を記録、ボタンを押していても同じイベントが何度も作られないため
/// </summary>
    bool[] Iactive;

/// <summary>
/// 現フレームの入力のリスト
/// </summary>
    List<Input_st> Ilist;

    void Start()
    {
        Iactive=new bool[12];
        TargetTL=FindObjectOfType<PC_Inst_Timeline>();
        Ilist=new List<Input_st>();
    }

    void Update()
    {
        //タイマーリセットしたら入力もリセット
        if(localTime>TL_TimeLineMng.ctime)
        {
            Iactive=new bool[12];
            Ilist.Clear();
        }

        localTime=TL_TimeLineMng.ctime;
       
    if(localTime>0.0001f){
        if(UT_InputFilter.GetU())
        {
            if(!Iactive[(int)Input_st.W/2]){
            Ilist.Add(Input_st.W);
            Iactive[(int)Input_st.W/2]=true;
            }

        }else
        if(Iactive[(int)Input_st.W/2])
        {
            Ilist.Add(Input_st.Wr);
            Iactive[(int)Input_st.W/2]=false;

        }

        if(UT_InputFilter.GetL())
        {
            if(!Iactive[(int)Input_st.A/2]){

            Ilist.Add(Input_st.A);
            Iactive[(int)Input_st.A/2]=true;
            }

        }
        else
        if(Iactive[(int)Input_st.A/2])
        {
            Ilist.Add(Input_st.Ar);
            Iactive[(int)Input_st.A/2]=false;


        }


        if(UT_InputFilter.GetTriangle())
        {
            if(!Iactive[(int)Input_st.Tri/2]){

            Ilist.Add(Input_st.Tri);
            Iactive[(int)Input_st.Tri/2]=true;
            }

        }
        else
        if(Iactive[(int)Input_st.Tri/2])
        {
            Ilist.Add(Input_st.Trir);
            Iactive[(int)Input_st.Tri/2]=false;


        }

       if(UT_InputFilter.GetD())
        {
            if(!Iactive[(int)Input_st.S/2]){

            Ilist.Add(Input_st.S);
            Iactive[(int)Input_st.S/2]=true;
            }

        }else
        if(Iactive[(int)Input_st.S/2])
        {
            Iactive[(int)Input_st.S/2]=false;

            Ilist.Add(Input_st.Sr);


        }

           if(UT_InputFilter.GetR())
        {
            if(!Iactive[(int)Input_st.D/2]){

            Iactive[(int)Input_st.D/2]=true;

            Ilist.Add(Input_st.D);
            }

        }else
        if(Iactive[(int)Input_st.D/2])
        {
            Iactive[(int)Input_st.D/2]=false;

            Ilist.Add(Input_st.Dr);


        }


        if(UT_InputFilter.GetX())
        {
            if(!Iactive[(int)Input_st.X/2]){

            Iactive[(int)Input_st.X/2]=true;

            Ilist.Add(Input_st.X);
            }
        }else
        if(Iactive[(int)Input_st.X/2])
        {
            Iactive[(int)Input_st.X/2]=false;

            Ilist.Add(Input_st.Xr);
        }




    
    for (var i = 0; i < Ilist.Count; i++)
    {  
       TargetTL.CreateEvent(Ilist[i],localTime+(0.001f*i));
    }
    
    Ilist.Clear();
    }

    if(Input.GetKeyDown(KeyCode.T))
    {
        Ilist.Clear();
        TargetTL.EventList.Clear();
    }

    }
   static public void UpdateTarget(GameObject NEW)
    {
        TargetTL=NEW.GetComponentInParent<PC_Inst_Timeline>();
    }

}
