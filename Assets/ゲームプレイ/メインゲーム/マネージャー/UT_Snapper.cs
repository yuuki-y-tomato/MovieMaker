using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UT_Snapper : MonoBehaviour
{
    Transform par;
    void Start()
    {
   par=     GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        par.position=new Vector3((int)par.position.x,(int)par.position.y,(int)par.position.z);
    }
}
