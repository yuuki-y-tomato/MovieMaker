using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// インプット管理
/// </summary>
public class UT_InputFilter : MonoBehaviour
{
    public PlayerInput pi;

    public static float Axis;

    public static float GetHor()
    {    
        
      return Axis.x;
    }
    public static float GetVer()
    {    
      return Input.GetAxis("Vertical");
    }
    
        public static bool GetR()
    {    


        if(Input.GetAxis("Horizontal")>0)
        {
            return true;
        }else
        if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
        {
            return true;
        }


    return false;
    }
    public static bool GetL()
    {    
    if(Input.GetAxis("Horizontal")<0)
        {
            return true;
        }
else
        if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            return true;
        }
    return false;
    }
       public static bool GetU()
    {    
      
        if(Input.GetAxis("Vertical")>0)
        {
            return true;
        }

    return false;
    }
    public static bool GetD()
    {    
      
        if(Input.GetAxis("Vertical")<0)
        {
            return true;
        }

    return false;
    }





    public static bool GetCir()
    {
        return Input.GetButtonDown("Circle");
    }
    public static bool GetTriangle()
    {
        return Input.GetButtonDown("Triangle");
    }
    public static bool GetSquare()
    {
        return Input.GetButtonDown("Square");
    }
        public static bool GetX()
    {
            if(Input.GetButtonDown("X"))
            {
                return true;
            }else
            if(Input.GetKey(KeyCode.Space))
            {
                return true;
            }

        return false;
    }
    public static void AxisInput(InputAction.CallbackContext v)
    {
        Vector2 buf=v.ReadValue<Vector2>();

        


    }


}
