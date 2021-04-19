using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_InputFilter : MonoBehaviour
{

    static public bool isKB=false;
    public static float GetHor()
    {    
      return Input.GetAxis("Horizontal");
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
        }

    return false;
    }
    public static bool GetL()
    {    
            if(Input.GetAxis("Horizontal")<0)
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
            if(isKB)
            return Input.GetKey(KeyCode.Space);

        return Input.GetButtonDown("X");
    }

}
