using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GP_MovingPlatform : GP_GimmickBase
{
    // Start is called before the first frame update

    public GameObject PlatformCenter;
    private Vector2 Center;


    void Start()
    {

        Debug.Log(pos1.transform.position + "P1");
        Startpos = pos1.transform.position;// T.localToWorldMatrix.MultiplyPoint(pos1.transform.localPosition - PlatformCenter.transform.localPosition);

        Endpos = pos2.transform.position;// T.localToWorldMatrix.MultiplyPoint(pos2.transform.localPosition - PlatformCenter.transform.localPosition);



        Camera camera = FindObjectOfType<Camera>();

        //       Startpos-=PlatformCenter.transform.position;
        //     Endpos-=PlatformCenter.transform.position;



        T.position = Startpos;

    }
    void OnEnable()
    {
        TL_TimeLineMng.OnReset += ResetEvent;
    }
    void OnDisable()
    {
        TL_TimeLineMng.OnReset += ResetEvent;
    }
    void ResetEvent()
    {
        lerp = 0;
        T.position = Startpos;
        completed = false;
    }

    public bool test;

    // Update is called once per frame
    void Update()
    {

        T.position = Vector2.Lerp(Startpos, Endpos, lerp);
        if (test)
        {
            T.position = Vector2.Lerp(Startpos, Endpos, 0);
            lerp = 0;
            test = false;
            Startpos = pos1.transform.position;// T.localToWorldMatrix.MultiplyPoint(pos1.transform.localPosition - PlatformCenter.transform.localPosition);

            Endpos = pos2.transform.position;// T.localToWorldMatrix.MultiplyPoint(pos2.transform.localPosition - PlatformCenter.transform.localPosition);

        }

    }


    public Transform pos1;
    public Transform pos2;


    public Vector2 Startpos;

    public Vector2 Endpos;

    public float rate;
    [Range(0, 1)]
    public float lerp = 0;

    public Transform T;
    public override void Event(bool state, PC_Base User)
    {
        if (state && lerp < 1.0f)
        {

            lerp += rate * TL_TimeLineMng.delta;
        }
        else
        if (lerp >= 1.0f)
        {
            completed = true;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(this.transform, true);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.parent = null;
    }

}
