using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// インプット管理
/// </summary>
public class UT_InputFilter : MonoBehaviour
{

    public static float Axis;
  

    //*左スティック横軸入力を返す
    public static float GetHor()
    {
        return Input.GetAxis("Horizontal");

    }
    //*左スティック縦入力を返す
    public static float GetVer()
    {
        return Input.GetAxis("Vertical");
    }

    //*左スティック右入力されている場合trueを返す
    public static bool GetR()
    {


        if (Input.GetAxis("Horizontal") > 0)
        {
            return true;
        }
        else
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            return true;
        }


        return false;
    }
    //*左スティック左入力されている場合trueを返す
    public static bool GetL()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            return true;
        }
        else
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            return true;
        }
        return false;
    }
    //*左スティック上入力されている場合trueを返す
    public static bool GetU()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            return true;
        }

        return false;
    }
    //*左スティック下入力されている場合trueを返す
    public static bool GetD()
    {

        if (Input.GetAxis("Vertical") < 0)
        {
            return true;
        }

        return false;
    }


    //右側＝ABXYボタンのこと

    //*右側、右ボタン入力の場合True 
    public static bool GetCir()
    {
        return Input.GetButtonDown("Circle");
    }
    //*右側、上ボタン入力の場合True 
    public static bool GetTriangle()
    {
        return Input.GetButtonDown("Triangle");
    }
    
    //*右側、左ボタン入力の場合True 
    public static bool GetSquare()
    {
        return Input.GetButtonDown("Square");
    }

    //*右側、下ボタン入力の場合True 
    public static bool GetX()
    {
        if (Input.GetButtonDown("X") || Input.GetKey(KeyCode.Space))
        {
            return true;
        }

        return false;
    }


    //*右トリガー入力している間、Trueを返す
    public static bool GetRTrigger()
    {
        return false;
    }

}
