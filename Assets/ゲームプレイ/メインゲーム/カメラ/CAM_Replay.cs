using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_Replay : MonoBehaviour
{


    List<PC_Type_Moover> CharList;
   public Camera Cam;
   public Vector3 vel;
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
isactive=false;

        IntendedCoords=Cam.transform.position;

        FindBoundary();
    }
    public float factor;

    public    float zoomdrag;
       public float zoomrate;

    // Update is called once per frame


    private Vector3 v;

   public bool isactive;
public    float EffectMult;

    void Update()
    {
        if(isactive){
            if(TL_TimeLineMng.ctime==0)
            {
                TL_TimeLineMng.run(true);
            }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var b in CharList)
            {
                Debug.Log(Cam.WorldToViewportPoint(b.transform.position).ToString("F4"));
            }
        }



        CamMovement();


        zoom();
        EffectOffset.z=0;
        Cam.transform.position=IntendedCoords+(EffectOffset*EffectMult);
         Cam.transform.position=new Vector3(Cam.transform.position.x,Cam.transform.position.y,-10);
        }
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
           // if (!(Math.Abs(buf.x) > 1 || Math.Abs(buf.y) > 1)&&!b.completed)
            if (!b.completed)
            {
                ct++;
                v += Cam.WorldToViewportPoint(b.transform.position);
            }
        }
     
  
        if(ct>0){
        v /= ct;

        //  Cam.transform.position=Cam.ViewportToWorldPoint(v);
        //v.z=-10;
        //      Vector3 curpoint=Cam.WorldToViewportPoint(Cam.transform.position);
        //       Cam.transform.position= Cam.ViewportToWorldPoint(Vector3.Lerp(curpoint,v,factor));

//        vel += v - Cam.WorldToViewportPoint(IntendedCoords);
        vel += v - new Vector3(0.5f,0.5f,0);
  
        vel *= 0.7f;
        vel.y*=0.8f;
//        Debug.Log(IntendedCoords);
        IntendedCoords += vel;
    /*    IntendedCoords = new Vector3(
            Math.Min(Edge.z, Math.Max(Edge.x, IntendedCoords.x)),
            Math.Min(Edge.w, Math.Max(Edge.y, IntendedCoords.y))
            , -10);
*/
        }
    }

    float zoomv = 0;
    bool moving;

    public float CharVisibility_min=0.2f;
    public float CharVisibility_max=0.4f;



    void zoom()
    {
        float d = 0;
        int completedchar=0;
        for (int i = 0; i < CharList.Count; i++)
        {
            if(!CharList[i].completed){
            d += Vector2.Distance(v, CharList[i].transform.position);
                   completedchar++;
        }
        }
        bool[] k = new bool[CharList.Count];
        for (int i = 0; i < CharList.Count; i++)
        {
            if(!CharList[i].completed){

//            Debug.Log(Vector2.Distance(v, CharList[i].transform.position) / d);
            if (Vector2.Distance(v, CharList[i].transform.position) / d > 0.7f)
            {
                k[i] = false;
            }
            else
            {
                k[i] = true;
            }
        }}

        for (int i = 0; i < CharList.Count; i++)
        {
            if (k[i])
            {
            if(!CharList[i].completed){

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
            }
     
            
            if(CharList.Count-completedchar==1&&Cam.orthographicSize>(ZoomMin/2.0f))
                {
                    
                    zoomv-=zoomrate*TL_TimeLineMng.delta;
                }

      //  Debug.Log(CharList.Count-completedchar);
     //   Debug.Log(completedchar);

        }
    

        zoomv *= zoomdrag;
        Cam.orthographicSize += zoomv;
        Cam.orthographicSize = Math.Max(Math.Min(Cam.orthographicSize, ZoomMax), ZoomMin);

    }

    /// <summary>
    /// LR floor, LR ceil
    /// </summary>
public    Vector4 Edge;
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

    

}
