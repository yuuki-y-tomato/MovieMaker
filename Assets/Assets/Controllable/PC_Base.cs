using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Base : MonoBehaviour
{
    // Start is called before the first frame update



    public PC_Inst_Control cont_ref;
    public Transform T;

    public Vector3 Init_P;

    public bool Cir,Squ,Tri,X;
    public bool Left,Up,Down,Right;
    
    private float timer;

    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

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
        
        timer=TL_TimeLineMng.ctime;
    }
}
