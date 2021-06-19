using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_Gameplay : MonoBehaviour
{
    // Start is called before the first frame update

    #region Var
    Transform T;
    public Transform Targetpos;

    public bool isactive;
    public Camera Cam;

    private PC_Type_Moover pc;
    #endregion
    void Awake()
    {

        FindBoundary();
        if (PC_Control.TargetTL != null)
        {
            Targetpos = PC_Control.TargetTL.GetComponent<Transform>();
        }
        Cam = GetComponent<Camera>();
        T = GetComponent<Transform>();
        //    Debug.Log("KUGUGUYOG");
        isactive = true;
        defsize = Cam.orthographicSize;
     //   def = Cam.WorldToViewportPoint(cl_T.transform.position);
        StartCoroutine("ClapperPlacement");
    }
    void Update()
    {

        if (Targetpos == null || pc == null)
        {
            //         Debug.Log("TargetUpdate");
            if (PC_Control.TargetTL != null)
            {
                Targetpos = PC_Control.TargetTL.GetComponent<Transform>();
                pc = PC_Control.TargetTL.GetComponent<PC_Type_Moover>();
            }
        }
        else
        if (isactive)
        {
            //            Debug.Log("FUNCTION");
            Move();
            zoom();
            T.position = new Vector3(T.position.x, T.position.y, -10f);
        }

    }


    #region  Movement
     #region  Move
    private Vector3 v;

    public float speed;
    public float drag = 0.8f;
    void Move()
    {
        v = speed * (Cam.WorldToViewportPoint(Targetpos.position) - new Vector3(0.5f, 0.5f, 0));
        v *= drag;
        v.y *= 0.5f;
        if (MG_StateManager.state == MG_StateManager.States.Ready)
        {
            v += readyoffset;
        }

        T.position += v;

    }

    #endregion
     #region  Zoom
    public float max;
    public float retmul = 2;
    public float zoomrate = 0.15f;
    private float defsize;


    [Header("Ready")]
    public float readyzoom = 2.0f;
    public Vector3 readyoffset;
    void zoom()
    {
        float b = defsize;

        if (pc != null)
        {
            if (pc.Usable && pc.Down)
            {
                if (Cam.orthographicSize < max)
                {
                    //   Cam.orthographicSize+=zoomrate*Time.deltaTime;


                    Cam.orthographicSize += (max - Cam.orthographicSize) * zoomrate * Time.deltaTime;

                }
            }



            if (MG_StateManager.state == MG_StateManager.States.Ready)
            {

                Cam.orthographicSize += readyzoom * (b / readyzoom - Cam.orthographicSize) * zoomrate * Time.deltaTime;

            }
            else
            {
                if (Math.Abs(b - Cam.orthographicSize) > 0.25f)
                {
                    Cam.orthographicSize += readyzoom * (b - Cam.orthographicSize) * zoomrate * Time.deltaTime;


                }
            }
            //        Debug.Log("working");
        }
    }

    #endregion
     #region Boundary
    private Vector4 Edge;
    public void FindBoundary()
    {


        GameObject[] Boundary = new GameObject[2];
        Boundary = GameObject.FindGameObjectsWithTag("LevelBoundary");

        Edge.x = Math.Min(Boundary[0].transform.position.x, Boundary[1].transform.position.x);
        Edge.y = Math.Min(Boundary[0].transform.position.y, Boundary[1].transform.position.y);
        Edge.z = Math.Max(Boundary[0].transform.position.x, Boundary[1].transform.position.x);
        Edge.w = Math.Max(Boundary[0].transform.position.y, Boundary[1].transform.position.y);

        Boundary[0].GetComponent<SpriteRenderer>().enabled = false;
        Boundary[1].GetComponent<SpriteRenderer>().enabled = false;

    }

    #endregion
    #endregion
   



    public void UpdateTarget(PC_Base NEW)
    {
        Targetpos = NEW.GetComponent<Transform>();
    }

    #region ClapperControl

    [Header("Clapper")]
    public Clapper clapper;
    public Vector2 def;
    public Transform cl_T;
    public Vector2 vel;
    public float cspeed;
    public Vector3 cl_readyoffset;
    public float ReadyScale;
    public float GPscale;

    IEnumerator ClapperPlacement()
    {
        Vector3 buf;
        for (; ; )
        {
           // Vector2 buf = Cam.WorldToViewportPoint(T.position);

         //   cl_T.position = (buf - def).normalized * cspeed;
            buf=new Vector3();
                if(MG_StateManager.state==MG_StateManager.States.Ready)
            {
                buf=cl_readyoffset;
            }

            float tgtscale=0.03f;
            switch(MG_StateManager.state)
            {
                case MG_StateManager.States.Ready:
                    tgtscale=Clapper.lerp(tgtscale,ReadyScale,cspeed);
                break;
                case MG_StateManager.States.Gameplay:
                    tgtscale=Clapper.lerp(tgtscale,GPscale,cspeed);
                break;
                
            }

            cl_T.localScale=new Vector3(tgtscale,tgtscale,1);
            

            cl_T.position = Cam.ViewportToWorldPoint(def) + new Vector3(0, 0, 5)+buf;
    
            
            yield return null;
        }

    }

 

    #endregion

    #region StateTransition

    public void Ready_to_GP()
    {
        StopCoroutine("ClapperPlacement");
        StartCoroutine("CL_Ready_to_GP");
    }
    IEnumerator CL_Ready_to_GP()
    {
        for (; Cam.WorldToViewportPoint(cl_T.position).y > -2;)
        {
            cl_T.position += new Vector3(0, -cspeed, 0);

            yield return null;
        }
        MG_StateManager.state = MG_StateManager.States.Gameplay;
        StartCoroutine("ClapperPlacement");

    }
    #endregion


}
