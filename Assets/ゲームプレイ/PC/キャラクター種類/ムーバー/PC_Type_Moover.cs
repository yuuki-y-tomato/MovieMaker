using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 横移動とジャンプのできるキャラクター
/// </summary>
public class PC_Type_Moover : PC_Base
{
    
    private Transform T;

 public float vertical_vel;
 public float horizontal_vel;
 
public float speed;

public float drag=0.7f;

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


   
     
        T=GetComponent<Transform>();

     rb=GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
   
        move();
    jumpTimer= Math.Max( jumpTimer-(TL_TimeLineMng.delta)*timermul,0);
    
  //  vertical_vel=smin(jumpTimer,JumpHeght,JumpFloatyness)/10;



    T.position+=new Vector3(horizontal_vel,vertical_vel,0);
    
    horizontal_vel*=drag;

if(Input.GetKey(KeyCode.R))
{
    rb.velocity=new Vector2();
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
