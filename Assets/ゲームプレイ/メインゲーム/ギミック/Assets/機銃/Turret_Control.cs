using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    [Header("発射間隔(秒)")]
    public float DownTime;
    [Header("弾速度")]
    public float Speed;
    [Header("発射方向")]
    public Bullet.dir dir;

    private float timer;

    [Header("メーター")]
    public GameObject Meter;
    [Header("メーターマテリアル")]
    public Material Base;
    private Material MeterMat;
    [Header("アニメーションコントローラー")]
    public Animator ac;

    void Start()
    {
        MeterMat = Instantiate(Base);
        Meter.GetComponent<SpriteRenderer>().material = MeterMat;
    }

    // Update is called once per frame

    void OnEnable()
    {
        TL_TimeLineMng.OnReset += ResetEvent;
    }
    void OnDisable()
    {
        TL_TimeLineMng.OnReset -= ResetEvent;

    }

    void ResetEvent()
    {
        prevtimer=0;
        Bullet.reset();
    }
    float prevtimer;
    void Update()
    {
        timer=TL_TimeLineMng.ctime-prevtimer;
        

        if (timer > DownTime)
        {
            generate();
            timer = 0;
            ac.Play("Fire");
            prevtimer=TL_TimeLineMng.ctime;
        }
        MeterMat.SetFloat("_Timer", TL_TimeLineMng.ctime);
        MeterMat.SetFloat("_Meter", timer / DownTime);


    }

    void generate()
    {
        Bullet.Create(dir, this.transform.position, Speed);
    }

}
