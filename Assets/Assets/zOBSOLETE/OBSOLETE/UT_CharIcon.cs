using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_CharIcon : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform T;
    private Transform TT;
    void Start()
    {
        T=GetComponent<Transform>();
    }


        
    // Update is called once per frame
    void Update()
    {
            TT=PC_Control.TargetTL.GetComponent<Transform>();

            T.position=new Vector3(TT.position.x,TT.position.y+1,0);

    }
}
