using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Type_Moover : PC_Base
{
    // Start is called before the first frame update


 public Vector2 vel;
 public float vertical_vel;
 public float horizontal_vel;
 
public float speed;

public float drag;

float jumpTimer;
bool jumping;

public  float JumpHeght;
public float JumpVelocity;
public float JumpFloatyness;
public  float timermul;
    public Rigidbody2D rb;
    void Start()
    {
Physics2D.IgnoreLayerCollision(3,3);


   
        cont_ref= GetComponent<PC_Inst_Control>();
        T=GetComponent<Transform>();
        
        Init_P=GetComponent<Transform>().position;

     rb=GetComponent<Rigidbody2D>();

        vel=new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
   
        move();
    jumpTimer= Math.Max( jumpTimer-(TL_TimeLineMng.delta)*timermul,0);
    
  //  vertical_vel=smin(jumpTimer,JumpHeght,JumpFloatyness)/10;



    T.position+=new Vector3(horizontal_vel,vertical_vel,0);
    
    horizontal_vel*=0.7f;

if(Input.GetKey(KeyCode.R))
{
    rb.velocity=new Vector2();
    vel=new Vector2();
}

    }

void move()
{

    if(Right)
    {
        horizontal_vel+=TL_TimeLineMng.delta;
    }
    if(Left)
    {
        horizontal_vel-=TL_TimeLineMng.delta;
    }

  if(X&&!jumping)
    {
        jumping=true;
     //   vel
     jumpTimer=JumpVelocity;
    rb.AddForce(new Vector2(0,JumpHeght));

    }
    if(!X)
    {
        jumping=false;
    }

}
float smin(float val,float lim, float smooth)
{

float buf;
buf=Math.Max(smooth-Math.Abs(val-lim),0)/smooth;

return Math.Min(val,lim)-buf*buf*smooth*0.25f;


}


}
