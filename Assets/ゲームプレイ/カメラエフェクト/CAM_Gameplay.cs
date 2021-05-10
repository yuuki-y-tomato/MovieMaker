using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_Gameplay : MonoBehaviour
{
    // Start is called before the first frame update


    Transform T;
   public Transform Targetpos;

    public bool isactive;
 public  Camera Cam;



    void Awake()
    {
        FindBoundary();
        if(PC_Control.TargetTL!=null)
        {
        Targetpos=PC_Control.TargetTL.GetComponent<Transform>();
        }
        Cam=GetComponent<Camera>();
        T=GetComponent<Transform>();
    //    Debug.Log("KUGUGUYOG");
        isactive=true;
    }


    // Update is called once per frame
    void Update()
    {
        if(Targetpos==null)
        {
   //         Debug.Log("TargetUpdate");
    if(PC_Control.TargetTL!=null)
        {
        Targetpos=PC_Control.TargetTL.GetComponent<Transform>();
        }
        }else
        if(isactive)
        {
//            Debug.Log("FUNCTION");
        Move();
        T.position=new Vector3(T.position.x,T.position.y,-10f);
        }
    }

    private Vector3 v;

    public float speed;
    public float drag=0.8f;
    void Move()
    {
        v=speed*(Cam.WorldToViewportPoint(Targetpos.position)-new Vector3(0.5f,0.5f,0));
        v*=drag;
        v.y*=0.5f;
        T.position+=v;

    }

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


    public void UpdateTarget(PC_Base NEW)
    {
        Targetpos=NEW.GetComponent<Transform>();
    }



}
