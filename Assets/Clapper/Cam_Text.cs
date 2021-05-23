using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Text : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform RightLong,LeftLong,RightShort,LeftShort;
    private float rl,ll,rs,ls;
    void Start()
    {
        rl=Random.value*360;
        ll=Random.value*360;
        rs=Random.value*360;
        ls=Random.value*360;
        
        
    }
    public float speed;
    // Update is called once per frame
    void Update()
    {
        float buf;
        buf=speed*Time.deltaTime;
        rl+=buf;
        ll+=buf;
        rs+=buf/12;
        ls+=buf/12;

        RightLong.transform.localRotation=Quaternion.Euler(0,0,rl);
        LeftLong.transform.localRotation=Quaternion.Euler(0,0,ll);
        RightShort.transform.localRotation=Quaternion.Euler(0,0,rs);
        LeftShort.transform.localRotation=Quaternion.Euler(0,0,ls);




    }
}
