using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_MovingPlatform : GP_GimmickBase
{
    // Start is called before the first frame update

    public GameObject PlatformCenter;
    private Vector2 Center;

    Rigidbody2D rb;
    void Start()
    {
        T=GetComponent<Transform>();
        Debug.Log(pos1.transform.position+"P1");
        Startpos=T.localToWorldMatrix.MultiplyPoint(pos1.transform.localPosition-PlatformCenter.transform.localPosition);

        Endpos=T.localToWorldMatrix.MultiplyPoint(pos2.transform.localPosition-PlatformCenter.transform.localPosition);
        


Camera camera=FindObjectOfType<Camera>();

 //       Startpos-=PlatformCenter.transform.position;
   //     Endpos-=PlatformCenter.transform.position;

        pos1.active=false;
        pos2.active=false;
        rb=GetComponent<Rigidbody2D>();
        T.position=Startpos;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(localtimer>TL_TimeLineMng.ctime)
        {
            lerp=0;
            T.position=Startpos;
            completed=false;
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
   public override void Event(bool state,PC_Base User)
    {
        if(state&&lerp<1.0f)
        {
          ///  rb.AddForce(Vector2.Lerp(Startpos,Endpos,lerp));
            T.position=Vector2.Lerp(Startpos,Endpos,lerp);
            lerp+=rate*TL_TimeLineMng.delta;
        }else
        if(lerp>=1.0f)
        {
            completed=true;
        }
        
    }

   
   void OnCollisionEnter2D(Collision2D other)
   {
       other.gameObject.transform.SetParent(this.transform,true);
   }

   void OnCollisionExit2D(Collision2D other)
   {
       other.gameObject.transform.parent=null;
   }

}
