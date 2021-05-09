using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_Replay : MonoBehaviour
{


    List<PC_Type_Moover> CharList;
    Camera Cam;
    Vector3 vel;
    // Start is called before the first frame update

    public Vector3 IntendedCoords;
    public Vector3 EffectOffset;


    void Start()
    {
        
        CharList = new List<PC_Type_Moover>();
        CharList.AddRange(FindObjectsOfType<PC_Type_Moover>());
       // Cam = FindObjectOfType<Camera>();
        Cam=GetComponent<Camera>();
        IntendedCoords=new Vector3();
        EffectOffset=new Vector3();


        IntendedCoords=Cam.transform.position;

        FindBoundary();
    }
    public float factor;

    public    float zoomdrag;
       public float zoomrate;

    // Update is called once per frame


    private Vector3 v;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var b in CharList)
            {
                Debug.Log(Cam.WorldToViewportPoint(b.transform.position).ToString("F4"));
            }
        }



        CamMovement();


        zoom();

        Cam.transform.position=IntendedCoords+EffectOffset;
         Cam.transform.position=new Vector3(Cam.transform.position.x,Cam.transform.position.y,-10);
    }
   public float ZoomMax=100;
   public float ZoomMin=6;

    void CamMovement()
    {

        int ct = 0;
        v=new Vector3();
        foreach (var b in CharList)
        {
            Vector3 buf = Cam.WorldToViewportPoint(b.transform.position);
            if (!(Math.Abs(buf.x) > 1 || Math.Abs(buf.y) > 1))
            {
                ct++;
                v += Cam.WorldToViewportPoint(b.transform.position);
            }
        }
        v /= ct;

        //  Cam.transform.position=Cam.ViewportToWorldPoint(v);
        //v.z=-10;
        //      Vector3 curpoint=Cam.WorldToViewportPoint(Cam.transform.position);
        //       Cam.transform.position= Cam.ViewportToWorldPoint(Vector3.Lerp(curpoint,v,factor));

//        vel += v - Cam.WorldToViewportPoint(IntendedCoords);
        vel += v - new Vector3(0.5f,0.5f,0);
  
        vel *= 0.7f;
        
        IntendedCoords += vel;
    /*    IntendedCoords = new Vector3(
            Math.Min(Edge.z, Math.Max(Edge.x, IntendedCoords.x)),
            Math.Min(Edge.w, Math.Max(Edge.y, IntendedCoords.y))
            , -10);
*/
    }

    float zoomv = 0;
    bool moving;

    public float CharVisibility_min=0.2f;
    public float CharVisibility_max=0.4f;



    void zoom()
    {

        float d = 0;
        for (int i = 0; i < CharList.Count; i++)
        {
            d += Vector2.Distance(v, CharList[i].transform.position);
        }
        bool[] k = new bool[CharList.Count];
        for (int i = 0; i < CharList.Count; i++)
        {
//            Debug.Log(Vector2.Distance(v, CharList[i].transform.position) / d);
            if (Vector2.Distance(v, CharList[i].transform.position) / d > 0.7f)
            {
                k[i] = false;
            }
            else
            {
                k[i] = true;
            }
        }

        for (int i = 0; i < CharList.Count; i++)
        {
            if (k[i])
            {
                float buf = Vector2.Distance(Cam.WorldToViewportPoint(CharList[i].transform.position), new Vector2(0.5f, 0.5f));
                if (buf < CharVisibility_min)
                {
                    zoomv -= zoomrate*TL_TimeLineMng.delta;
                }
                if (buf > CharVisibility_max)
                {
                    zoomv += zoomrate*TL_TimeLineMng.delta;
                }
            }
            else
            {
                Debug.Log("Ignored");
            }
        }
    

        zoomv *= zoomdrag;
        Cam.orthographicSize += zoomv;
        Cam.orthographicSize = Math.Max(Math.Min(Cam.orthographicSize, ZoomMax), ZoomMin);

    }

    /// <summary>
    /// LR floor, LR ceil
    /// </summary>
public    Vector4 Edge;
    void FindBoundary()
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

    

}
