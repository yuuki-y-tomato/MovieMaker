using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Type_Moover : MonoBehaviour
{
    // Start is called before the first frame update

PC_Inst_Control cont_ref;
Transform T;

Vector3 Init_P;


 public Vector2 vel;
public float speed;
public float Jheight;
public float drag;

public bool IsAirbourn;
public bool ascending=false;
public float Jtimer=0;

public float grav;
float Grounded;
    private List<UT_Inst_Colpoints> Colpoints;
    void Start()
    {
        Colpoints=new List<UT_Inst_Colpoints>();
       Colpoints.AddRange(GetComponentsInChildren<UT_Inst_Colpoints>());

        cont_ref= GetComponent<PC_Inst_Control>();
        T=GetComponent<Transform>();
        
        Init_P=GetComponent<Transform>().position;
        IsAirbourn=false;
        vel=new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
    Grounded=GetColCount();        

/*

        switch(cont_ref.Input_States[(int)UT_r.inp.W])
        {
            case 0:
            vel+=new Vector2(0,speed)*TL_TimeLineMng.delta;
              //  T.position+=new Vector3(0,1,0)*TL_TimeLineMng.delta;
            break;
        

        }
             switch(cont_ref.Input_States[(int)UT_r.inp.S])
        {
            case 0:
            vel+=new Vector2(0,-speed)*TL_TimeLineMng.delta;

               // T.position+=new Vector3(0,-1,0)*TL_TimeLineMng.delta;
            break;
        }*/

    
  

     switch(cont_ref.Input_States[(int)UT_r.inp.A])
        {
            case 0:
            vel+=new Vector2(-speed,0)*TL_TimeLineMng.delta;
         
           //     T.position+=new Vector3(-1,0,0)*TL_TimeLineMng.delta;
            break;
        }

 


     switch(cont_ref.Input_States[(int)UT_r.inp.D])
        {
            case 0:
            
            vel+=new Vector2(speed,0)*TL_TimeLineMng.delta;
         
               // T.position+=new Vector3(1,0,0)*TL_TimeLineMng.delta;
            break;
        }



        switch(cont_ref.Input_States[4])
        {
            case 0:

        if((Grounded>0.5f)){
            
            ascending=true;
            Jtimer=0.15f;
        }
              //  T.position+=new Vector3(0,1,0)*TL_TimeLineMng.delta;
            break;

            case 1:
            if(ascending)
            {
                ascending=false;
            }

            break;
        

        }

        if(ascending)
        {
            Jtimer+=TL_TimeLineMng.delta*3;
            vel.y=(float)Math.Min(Jheight*Math.Sin(Jtimer*Math.PI),Jheight/0.5);

            if(Jtimer>(1.1f*TL_TimeLineMng.mult))
            {
                ascending=false;
            }

        }











/*

//    rb.velocity+=vel;
if(ascending)
{
    Jtimer+=TL_TimeLineMng.delta*3;
    vel.y=Jheight*(float)Math.Cos(Math.Min(Jtimer,1.24f));

    if(Jtimer>1)
    {
        Jtimer=0;
        ascending=false;
    }

   // Jtimer=Jheight/T.position.y;
}

*/

    if(Grounded<0.1f&&!ascending)
    {
        vel.y-=grav*TL_TimeLineMng.delta;
    }

    T.position+=new Vector3(vel.x,vel.y,0);

    vel*=0.7f;
if(Input.GetKey(KeyCode.R))
{
    vel=new Vector2();
}
//vel=new Vector2();
    }

    public float GetColCount()
    {
        int buf=0;
        foreach (var b in Colpoints)
        {
            if(b.colliding)
            {
                buf++;
            }
        }
        if(buf==0)
        {
            return 0;
        }
        return Colpoints.Count/buf;
    }




}
