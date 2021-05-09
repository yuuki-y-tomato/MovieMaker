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

    public Vector3 velo;

    public float speed;

    public float drag = 0.7f;

    float jumpTimer;
    bool jumping;

    public float JumpHeght;
    public float JumpVelocity;
    public float JumpFloatyness;
    public float timermul;
    public Rigidbody2D rb;


    float basegravity;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 3);

    velo=new Vector3();


        T = GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        basegravity = rb.gravityScale;

    }

    int skipper=0;

    // Update is called once per frame
    void Update()
    {
       rb.gravityScale = basegravity * TL_TimeLineMng.mult;
    skipper++;
        if(skipper%(TL_TimeLineMng.mult)==0)
        {
        move();
        T.position+=velo;
        velo*=drag;
        }




        if (Input.GetKey(KeyCode.R))
        {
            rb.velocity = new Vector2();

        }

    Use();
    }

 

    void move()
    {

        if (Right)
        {
            horizontal_vel += TL_TimeLineMng.delta;
            velo.x+= TL_TimeLineMng.delta;
        }
        if (Left)
        {
            horizontal_vel -= TL_TimeLineMng.delta;
            velo.x-= TL_TimeLineMng.delta;
        
        }

        if (X && !jumping)
        {
            jumping = true;
            //   vel
            //  jumpTimer=JumpVelocity;
         //   rb.AddForce(new Vector2(0, JumpHeght));
            //vertical_vel = JumpHeght;
            velo.y= JumpHeght;


        }
        if (!X && Math.Abs(rb.velocity.y) < 0.0001f)
        {
            jumping = false;
        }


        if (Input.GetKey(KeyCode.R))
        {
            TL_TimeLineMng.ResetTimer();
            horizontal_vel = 0;
            vertical_vel = 0;
            ResetInput();
        }

    }
    float smin(float val, float lim, float smooth)
    {

        float buf;
        buf = Math.Max(smooth - Math.Abs(val - lim), 0) / smooth;

        return Math.Min(val, lim) - buf * buf * smooth * 0.25f;


    }

  public  GameObject UseTarget;
   public bool Usable=false;

    bool previnput;
    void Use()
    {

        if(Usable&&X!=previnput)
        {
            previnput=X;
            Debug.Log("SENT");
            UseTarget.GetComponent<GP_Usable>().Dispatch(X);
        }


    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("COLLIDE");
     if(other.gameObject.tag=="Usable")
     {
        Debug.Log("USABLE");

         UseTarget=other.gameObject;
        Usable=true;
     }   
        

    }
    
    private void  OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject==UseTarget)
        {
            Usable=false;
            UseTarget=null;
        }        


        
    }

    

}
