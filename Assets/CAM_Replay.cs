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
    void Start()
    {
        CharList = new List<PC_Type_Moover>();
        CharList.AddRange(FindObjectsOfType<PC_Type_Moover>());
        Cam = FindObjectOfType<Camera>();

    }
        public float factor;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var b in CharList)
            {
                Debug.Log(Cam.WorldToViewportPoint(b.transform.position).ToString("F4"));
            }
        }


   
            Vector3 v=new Vector3();
            int ct=0;
          foreach (var b in CharList)
            {
                Vector3 buf=Cam.WorldToViewportPoint(b.transform.position);
                if(!(Math.Abs(buf.x)>1||Math.Abs(buf.y)>1))
                {
                    ct++;
                v+=Cam.WorldToViewportPoint(b.transform.position);
                }
            }
            v/=ct;
            
          //  Cam.transform.position=Cam.ViewportToWorldPoint(v);
        //v.z=-10;
  //      Vector3 curpoint=Cam.WorldToViewportPoint(Cam.transform.position);
//       Cam.transform.position= Cam.ViewportToWorldPoint(Vector3.Lerp(curpoint,v,factor));

    vel+=v-Cam.WorldToViewportPoint(Cam.transform.position);
    vel*=0.7f;  
    
     Cam.transform.position+=vel;
        Cam.transform.position=new Vector3(Cam.transform.position.x,Cam.transform.position.y,-10);
    zoom(v);
    }
float zoomv=0;
    void zoom(Vector2 v)
    {

        float d=0;
        for(int i=0;i<CharList.Count;i++)
        {
            d+=Vector2.Distance(v,CharList[i].transform.position);
        }
        bool[] k=new bool[CharList.Count];
        for(int i=0;i<CharList.Count;i++)
        {
            Debug.Log(Vector2.Distance(v,CharList[i].transform.position)/d);
          if(Vector2.Distance(v,CharList[i].transform.position)/d>0.7f)
          {
              k[i]=false;
          }else
          {
              k[i]=true;
          }
        }

            for(int i=0;i<CharList.Count;i++)
            {
                if(k[i]){
                float buf=Vector2.Distance(Cam.WorldToViewportPoint(CharList[i].transform.position),new Vector2(0.5f,0.5f));
                if(buf<0.11)
                {
                    zoomv-=0.15f;
                }
                if(buf>0.4)
                {
                   zoomv+=0.15f;
                }
                }else
                {
                    Debug.Log("Ignored");
                }
            }
    zoomv*=0.75f;
     Cam.orthographicSize+=zoomv;
    Cam.orthographicSize=Math.Max(Math.Min(Cam.orthographicSize,100),6);

    }
    


    void FindBoundary()
    {
        GameObject TileMap;
      TileMap= GameObject.FindGameObjectWithTag("TileMap");
      
    }

}
