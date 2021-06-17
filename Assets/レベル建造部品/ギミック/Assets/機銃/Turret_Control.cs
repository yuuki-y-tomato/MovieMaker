using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{
    [Header("TurretControl")]
    public float DownTime;
    public float Speed;

    public Bullet.dir dir;

    private float timer;

    [Header("External")]
    public Material Base;
    private Material MeterMat;
    public GameObject Meter;
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
        Bullet.reset();
    }

    void Update()
    {

        timer += TL_TimeLineMng.delta;

        if (timer > DownTime)
        {
            generate();
            timer = 0;
            ac.Play("Fire");
        }
        MeterMat.SetFloat("_Timer", TL_TimeLineMng.ctime);
        MeterMat.SetFloat("_Meter", timer / DownTime);


    }

    void generate()
    {
        Bullet.Create(dir, this.transform.position, Speed);
    }

}
