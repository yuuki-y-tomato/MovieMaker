using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GP_MovingPlatform : GP_GimmickBase
{
    // Start is called before the first frame update

    public GameObject PlatformCenter;
    private Vector2 Center;



    [Header("足場開始点")]
    public Transform pos1;
    [Header("足場終点")]
    public Transform pos2;
    [Header("足場パス生成")]
    public bool GeneratePath;

    private Vector2 Startpos;

    private Vector2 Endpos;

    [Header("足場速度")]
    public float rate;
    [Header("足場移動パーセント")]
    [Range(0, 1)]
    public float lerp = 0;

    public Transform T;

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


    // Update is called once per frame
    void Update()
    {

        T.position = Vector2.Lerp(Startpos, Endpos, lerp);
        if (GeneratePath)
        {
            T.position = Vector2.Lerp(Startpos, Endpos, 0);
            lerp = 0;
            GeneratePath = false;
            Startpos = pos1.transform.position;// T.localToWorldMatrix.MultiplyPoint(pos1.transform.localPosition - PlatformCenter.transform.localPosition);

            Endpos = pos2.transform.position;// T.localToWorldMatrix.MultiplyPoint(pos2.transform.localPosition - PlatformCenter.transform.localPosition);

        }

    }


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
