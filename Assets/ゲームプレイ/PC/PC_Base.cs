using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///* キャラクターベースクラス
///* 入力状態管理してあるので派生してキャラクター種類を増やせます
/// 
/// </summary>
public class PC_Base : MonoBehaviour
{
    /// <summary>
    ///*初期座標　リセット用
    /// </summary>
    
    protected bool Cir,Squ,Tri,X;
    protected bool Left,Up,Down,Right;

    /// <summary>
    ///* PC_Inst_Controlから呼ばれ入力状態をアップデートする
    ///*
    /// </summary>
    /// <param name="id"></param>
   public void DispatchEvent(int id)
    {

    //    Debug.Log("Dispatched Event:"+id);
        switch(id)
        {
            case (int)PC_Control.Input_st.A:
                Left=true;
            break;
            case (int)PC_Control.Input_st.Ar:
                Left=false;
            break;

      case (int)PC_Control.Input_st.W:
                Up=true;
            break;
            case (int)PC_Control.Input_st.Wr:
                Up=false;
            break;

            
      case (int)PC_Control.Input_st.D:
                Right=true;
            break;
            case (int)PC_Control.Input_st.Dr:
                Right=false;
            break;

      case (int)PC_Control.Input_st.S:
                Down=true;
            break;
            case (int)PC_Control.Input_st.Sr:
                Down=false;
            break;


      case (int)PC_Control.Input_st.Space:
                X=true;
            break;
            case (int)PC_Control.Input_st.Spacer:
                X=false;
            break;




        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Cir=false;
            Squ=false;
            Tri=false;
            X=false;
            Up=false;
            Down=false;
            Right=false;
            Left=false;
        }
        
        
    }
}
