using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_MovingPlatform : GP_GimmickBase
{
    // Start is called before the first frame update
    void Start()
    {
        T=GetComponent<Transform>();
        Debug.Log(pos1.transform.position+"P1");
        Startpos=T.localToWorldMatrix.MultiplyPoint(pos1.transform.localPosition);
        Endpos=T.localToWorldMatrix.MultiplyPoint(pos2.transform.localPosition);
        


Camera camera=FindObjectOfType<Camera>();

 
        pos1.active=false;
        pos2.active=false;
        T.position=Startpos;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(localtimer>TL_TimeLineMng.ctime)
        {
            lerp=0;
            T.position=Startpos;
        }
        localtimer=TL_TimeLineMng.ctime;
    
    }

    float localtimer=0;
    public GameObject pos1;
    public GameObject pos2;


  public  Vector2 Startpos;

  public  Vector2 Endpos;

  public  float rate;
  [Range(0,1)]
  public  float lerp=0;

    Transform T;
   public override void Event(bool state)
    {
        if(state&&lerp<1.0f)
        {
            T.position=Vector2.Lerp(Startpos,Endpos,lerp);
            lerp+=rate*TL_TimeLineMng.delta;
        }
    }

   

}
