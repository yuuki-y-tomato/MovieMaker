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

    
    void Start()
    {

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
        }


    }

    void generate()
    {
        Bullet.Create(dir, transform.position,Speed);
    }

}
