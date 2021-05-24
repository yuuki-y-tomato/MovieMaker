using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Control : MonoBehaviour
{

    public float DownTIme;
    public float Speed;
    float localtimer;

    public Bullet.dir dir;

    private float timer;

    public Material Base;
    private Material MeterMat;    
    public GameObject Meter;
    public Animator ac;

    void Start()
    {
        MeterMat=Instantiate(Base);
        Meter.GetComponent<SpriteRenderer>().material=MeterMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (localtimer > TL_TimeLineMng.ctime)
        {
            Bullet.reset();
        }
        timer+=TL_TimeLineMng.ctime-localtimer;
        localtimer = TL_TimeLineMng.ctime;

        if (timer > DownTIme)
        {
            generate();
            timer = 0;
            ac.Play("Fire");
        }
        MeterMat.SetFloat("_Timer",TL_TimeLineMng.ctime);
        MeterMat.SetFloat("_Meter",timer/DownTIme);


    }

    void generate()
    {
        Bullet.Create(dir, this.transform.position,Speed);
    }

}
