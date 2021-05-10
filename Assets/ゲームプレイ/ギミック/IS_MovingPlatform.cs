using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IS_MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 Pos1;
    public Vector2 Pos2;
    private Transform T;

    public GameObject[] Points;

    void Start()
    {

        T=GetComponent<Transform>();    
        Pos1=Points[0].transform.position;
        Pos2=Points[1].transform.position;

    }

    // Update is called once per frame
    public double k;
    void Update()
    {
        k=Math.Sin(TL_TimeLineMng.ctime);

        T.position=Vector2.Lerp(Pos1,Pos2,((float)Math.Sin(TL_TimeLineMng.ctime)+1)/2);
    }
}
