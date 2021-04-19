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
    static public float mult=1;
    public float max;
    public static float Max_acc;
    private float tst=0;
    public float multplier=1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Max_acc=max;

        mult=multplier;
        if(tst>1)
        {

        delta=Time.deltaTime*mult;
        if(ctime<Max_acc)
        {
        ctime+=delta;
        }
        }
                tst+=Time.deltaTime;

        
        if(Input.GetKey(KeyCode.R))
        {
            ctime=0;
            tst=0;
        }

    }


    private void OnGUI() {
        GUI.Box(new Rect(Screen.width/2,10,400,20),ctime.ToString("F6"));
    }
}
