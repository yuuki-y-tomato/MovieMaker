using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// インプット管理
/// </summary>
public class UT_InputFilter : MonoBehaviour, Player.IMainActions
{

    public static float Axis;
    Player Iinput;

    [SerializeField]
    private static bool a, b, rt;
    [SerializeField]
    private static Vector2 ls;

    private void Awake()
    {
        Iinput = new Player();
        Iinput.Main.SetCallbacks(this);
        Iinput.Main.Enable();
    }

    public void OnA(InputAction.CallbackContext context)
    {
        a = context.ReadValueAsButton();
        Debug.Log(a);
    }

    public void OnB(InputAction.CallbackContext context)
    {
        b = context.ReadValueAsButton();

    }

    public void OnRTrig(InputAction.CallbackContext context)
    {

        rt = context.ReadValueAsButton();
    }
    public void OnLStick(InputAction.CallbackContext context)
    {
        ls = context.ReadValue<Vector2>();

        Debug.Log("APRESSED");
    }

    //*左スティック横軸入力を返す
    public static float GetHor()
    {
        return ls.x;//Input.GetAxis("Horizontal");

    }
    //*左スティック縦入力を返す
    public static float GetVer()
    {
        return ls.y;//Input.GetAxis("Vertical");
    }

    //*左スティック右入力されている場合trueを返す
    public static bool GetR()
    {

        return (ls.x > 0);
    }
    //*左スティック左入力されている場合trueを返す
    public static bool GetL()
    {


        return (ls.x < 0);
    }
    //*左スティック上入力されている場合trueを返す
    public static bool GetU()
    {
        return ls.y>0;
    }
    //*左スティック下入力されている場合trueを返す
    public static bool GetD()
    {

       return ls.y<0;
    }


    //右側＝ABXYボタンのこと

    //*右側、右ボタン入力の場合True 
    public static bool GetCir()
    {
        return b;//Input.GetButtonDown("Circle");
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
     return a;
    }


    //*右トリガー入力している間、Trueを返す
    public static bool GetRTrigger()
    {
        return rt;
        
    }

}
