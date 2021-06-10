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
        //   skipper++;
        //  if (skipper % (TL_TimeLineMng.mult) == 0 && TL_TimeLineMng.ctime > 0.001f)
        {
            move();
            T.position += velo;

            velo.x *= hordrag;
            //            velo *= drag;


        }




        if (Input.GetKey(KeyCode.R))
        {
            rb.velocity = new Vector2();

        }

        //        Use();
    }
    public float JumpGravity;
    public float FallGravity;
    public float JumpThreshhold;

    void move()
    {

        if (Right)
        {

            velo.x += TL_TimeLineMng.delta * speed;
        }
        if (cirref.r && velo.x > 0)
        {
            velo.x = 0;

        }

        if (Left)
        {

            velo.x -= TL_TimeLineMng.delta * speed;
        }
        if (cirref.l && velo.x < 0)
        {
            velo.x = 0;
        }

        //        if (X && !jumping)
        if (X && cirref.b && !jumping)
        {
            jumping = true;
            //   vel
            //  jumpTimer=JumpVelocity;
            //   rb.AddForce(new Vector2(0, JumpHeght));
            //vertical_vel = JumpHeght;
            //  velo.y = JumpHeght;
            rb.AddForce(new Vector2(0, JumpHeght));
        }
        if (cirref.b && jumping && !X)
        {
            jumping = false;
        }

        if (rb.velocity.y < JumpThreshhold && !X)
        {
            rb.gravityScale = FallGravity;
        }
        else
        {
            rb.gravityScale = JumpGravity;

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
            UseTarget.GetComponent<GP_Usable>().Dispatch(Down, this);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //     Debug.Log("SENT");

        //        Debug.Log("COLLIDE");
        /*
        if (other.gameObject.tag == "Usable")
        {
            //    Debug.Log("USABLE");

            UseTarget = other.gameObject;
            Usable = true;


        }*/
        if (other.gameObject.tag == "Death")
        {
            MG_StateManager Ref = FindObjectOfType<MG_StateManager>();
            Ref.RestartScene();
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Usable")
        {
            //    Debug.Log("USABLE");

            UseTarget = other.gameObject;
            Usable = true;

            Use();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //        Debug.Log("Exit");

        UseTarget.GetComponent<GP_Usable>().Dispatch(false, this);
    }



}
