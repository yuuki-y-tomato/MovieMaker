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

    public Vector3 velo;

    public float speed;

    public float drag = 0.7f;

    float jumpTimer;
    bool jumping;

    public float JumpHeght;


    public Rigidbody2D rb;
    public bool controlled;

    public scri cirref;

    float basegravity;
    void Start()
    {
        controlled = false;
        Physics2D.IgnoreLayerCollision(3, 3);

        velo = new Vector3();


        T = GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        basegravity = rb.gravityScale;

    }

    public float hordrag;
    public float vertdrag;


    int skipper = 0;

    // Update is called once per frame
    void Update()
    {
        rb.gravityScale = basegravity * TL_TimeLineMng.mult;
        skipper++;
        if (skipper % (TL_TimeLineMng.mult) == 0 && TL_TimeLineMng.ctime > 0.001f)
        {
            move();
            T.position += velo;

        velo.x*=hordrag;
        velo.y*=vertdrag;
//            velo *= drag;


        }




        if (Input.GetKey(KeyCode.R))
        {
            rb.velocity = new Vector2();

        }

        Use();
    }



    void move()
    {
        if(!cirref.r)
        {
        if (Right)
        {

            velo.x += TL_TimeLineMng.delta*speed;
        }
        }
          if(!cirref.l)
        {
        if (Left)
        {

            velo.x -= TL_TimeLineMng.delta*speed;
        }
        }

//        if (X && !jumping)
  if(X&&cirref.b&&!jumping)
        {
            jumping = true;
            //   vel
            //  jumpTimer=JumpVelocity;
            //   rb.AddForce(new Vector2(0, JumpHeght));
            //vertical_vel = JumpHeght;
            velo.y = JumpHeght;

        }
        if (cirref.b&&jumping&&!X)
        {
            jumping = false;
        }

        if(rb.velocity.y<0&&!X)
        {
            rb.gravityScale=basegravity*1.5f;
        }
        else
        {
            rb.gravityScale=basegravity;

        }



        if (Input.GetKey(KeyCode.R))
        {
            TL_TimeLineMng.ResetTimer();

            ResetInput();
        }

    }


    public GameObject UseTarget;
    public bool Usable = false;

    bool previnput;
    void Use()
    {

        if (Usable && Down != previnput)
        {
            previnput = Down;
            //       Debug.Log("SENT");
            UseTarget.GetComponent<GP_Usable>().Dispatch(Down, this);
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //        Debug.Log("COLLIDE");
        if (other.gameObject.tag == "Usable")
        {
            //    Debug.Log("USABLE");

            UseTarget = other.gameObject;
            Usable = true;
             

        }
        if (other.gameObject.tag == "Death")
        {
            FindObjectOfType<MG_StateManager>().RestartScene();
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == UseTarget)
        {
            UseTarget.GetComponent<GP_Usable>().Dispatch(false, this);
      
            Usable = false;
            UseTarget = null;
        }



    }



}
