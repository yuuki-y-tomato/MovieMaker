
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 今操作しているキャラクターに入力情報を送る
/// </summary>
public class PC_Control : MonoBehaviour
{
/// <summary>
/// インプット種類
///  #:ボタン押し　#r:ボタン放し
/// </summary>
    public enum Input_st
    {
        W,Wr,A,Ar,S,Sr,D,Dr,Space,Spacer,Shift,Shiftr,Latest,NULL

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
        Iactive=new bool[6];
        TargetTL=FindObjectOfType<PC_Inst_Timeline>();
        Ilist=new List<Input_st>();
    }

    void Update()
    {
        //タイマーリセットしたら入力もリセット
        if(localTime>TL_TimeLineMng.ctime)
        {
            Iactive=new bool[6];
        }

        localTime=TL_TimeLineMng.ctime;
       

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
            if(!Iactive[(int)Input_st.Space/2]){

            Iactive[(int)Input_st.Space/2]=true;

            Ilist.Add(Input_st.Space);
            }
        }else
        if(Iactive[(int)Input_st.Space/2])
        {
            Iactive[(int)Input_st.Space/2]=false;

            Ilist.Add(Input_st.Spacer);


        }

    
    for (var i = 0; i < Ilist.Count; i++)
    {  
       TargetTL.CreateEvent(Ilist[i],localTime+(0.001f*i));
    }

    Ilist.Clear();
    }
   static public void UpdateTarget(GameObject NEW)
    {
        TargetTL=NEW.GetComponentInParent<PC_Inst_Timeline>();
    }

}
