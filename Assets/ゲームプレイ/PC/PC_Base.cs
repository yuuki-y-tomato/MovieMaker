using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///* キャラクターベースクラス
///* PC_Inst_Controlから記録された入力をキャラクターに渡す
/// 
/// </summary>
public class PC_Base : MonoBehaviour
{
    public bool completed;

    public bool Cir, Squ, Tri, X;
    public bool Left, Up, Down, Right;

    /// <summary>
    ///* PC_Inst_Controlから呼ばれ入力状態をアップデートする
    ///*
    /// </summary>
    /// <param name="id"></param>
    /// 

    public void DispatchEvent(int id)
    {

        //    Debug.Log("Dispatched Event:"+id);
        switch (id)
        {
            case (int)PC_Control.Input_st.A:
                Left = true;
                break;
            case (int)PC_Control.Input_st.Ar:
                Left = false;
                break;

            case (int)PC_Control.Input_st.W:
                Up = true;
                break;
            case (int)PC_Control.Input_st.Wr:
                Up = false;
                break;


            case (int)PC_Control.Input_st.D:
                Right = true;
                break;
            case (int)PC_Control.Input_st.Dr:
                Right = false;
                break;

            case (int)PC_Control.Input_st.S:
                Down = true;
                break;
            case (int)PC_Control.Input_st.Sr:
                Down = false;
                break;


            case (int)PC_Control.Input_st.X:
                X = true;
                break;
            case (int)PC_Control.Input_st.Xr:
                X = false;
                break;

            case (int)PC_Control.Input_st.Tri:
                Tri = true;
                break;
            case (int)PC_Control.Input_st.Trir:
                Tri = false;
                break;



        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetInput();
        }


    }
   public void ResetInput()
    {
        completed=false;
        Cir = false;
        Squ = false;
        Tri = false;
        X = false;
        Up = false;
        Down = false;
        Right = false;
        Left = false;
        FindObjectOfType<PC_Control>().Ilist.Clear();
       GetComponent<PC_Inst_Control>().NextInput.type=PC_Control.Input_st.NULL;


    }
   public void HardReset()
   {
       ResetInput();

       GetComponent<PC_Inst_Control>().NextInput.type=PC_Control.Input_st.NULL;
        GetComponent<PC_Inst_Timeline>().EventList.Clear();
   }

}
