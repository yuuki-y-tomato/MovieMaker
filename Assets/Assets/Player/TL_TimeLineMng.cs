using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_TimeLineMng : MonoBehaviour
{
//*
//* CENTRAL TIME MANAGER FOR ALL ENTITIES
//*
//*
//*
//*



    // Start is called before the first frame update

    static public float ctime;
    static public float delta;
    public float mult=1;
    public float d;
    private float prevtime;

    void Start()
    {
        prevtime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            ctime=0;
        }
        
        delta=Time.deltaTime*mult;
        ctime+=delta;
        
    }
}
