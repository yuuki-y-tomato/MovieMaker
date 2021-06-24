using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 横移動とジャンプのできるキャラクター
/// </summary>
public class PC_Type_Moover : PC_Base
{



    #region Components

    private Transform T;
    public Rigidbody2D rb;

    [Header("External Components")]
    public PC_Colchecker cirref;

    #endregion

    public bool controlled;

    void Start()
    {
        controlled = false;
        Physics2D.IgnoreLayerCollision(3, 3);
        velo = new Vector3();
        T = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }


    #region ResetEventHandler
    void ResetEvent()
    {
        ResetInput();
        rb.velocity = new Vector2();
        velo=new Vector3();
    }
    void OnEnable()
    {
        TL_TimeLineMng.OnReset += ResetEvent;
    }
    void OnDisable()
    {
        TL_TimeLineMng.OnReset -= ResetEvent;
    }
    #endregion


    void Update()
    {

        move();




        if (Input.GetKey(KeyCode.R))
        {
            TL_TimeLineMng.ResetTimer();
        }

        //        Use();
    }

    //MOVEMENT FUNCTIONS
    #region Movement
    public Vector3 velo;

    void move()
    {

        Walk();
        Jump();

        T.position += velo * TL_TimeLineMng.delta;
        velo.x *= Drag * TL_TimeLineMng.mult;



    }

    #region Walk

    [Header("Walk")]
    public float Drag;
    public float speed;

    void Walk()
    {
        if (Right)
        {
            velo.x += speed;
        }
        if (cirref.r && velo.x > 0)
        {
            velo.x = 0;

        }

        if (Left)
        {
            velo.x -= speed;
        }
        if (cirref.l && velo.x < 0)
        {
            velo.x = 0;
        }



    }

    #endregion

    #region Jump

    #region  Variable
    float jumpTimer;
    bool isjumping;
    [Header("Jump")]
    [SerializeField] public float JumpHeght;
    [Header("Gravity")]
    [SerializeField] public float JumpGravity;
    [SerializeField] public float FallGravity;
    [SerializeField] public float JumpThreshhold;
    #endregion

    void Jump()
    {
        if (X && cirref.b && !isjumping)
        {
            isjumping = true;

            rb.AddForce(new Vector2(0, JumpHeght));
        }
        if (cirref.b && isjumping && !X)
        {
            isjumping = false;
        }

        if (rb.velocity.y > JumpThreshhold && !X)
        {
            rb.gravityScale = JumpGravity;

        }
        else
        {
            rb.gravityScale = FallGravity;
        }

    }
    #endregion

    #endregion

    //INTERACTION FUNCTIONS
    #region Use


    GameObject UseTarget;
    public bool Usable = false;

    bool previnput;
    void Use()
    {

        if (Usable && Down != previnput && UseTarget != null)
        {
            previnput = Down;
            UseTarget.GetComponent<GP_Usable>().Dispatch(Down, this);
        }


    }
    #endregion



    #region Collision

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Death")
        {
            MG_StateManager Ref = FindObjectOfType<MG_StateManager>();
            Ref.RestartScene();
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Usable")
        {
            UseTarget = other.gameObject;
            Usable = true;

            Use();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //        Debug.Log("Exit");
        if (other.gameObject.tag == "Usable")
        {
            UseTarget.GetComponent<GP_Usable>().Dispatch(false, this);
        }
    }

    #endregion

}
