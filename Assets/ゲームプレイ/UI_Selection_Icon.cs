using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Selection_Icon : MonoBehaviour
{
    

    Transform T;
   public PC_Base Target;

    public float Distance=10;

    void Start()
    {
        T=GetComponent<Transform>();
        Target=PC_Control.TargetTL.Target;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target!=PC_Control.TargetTL.Target)
        {
        Target=PC_Control.TargetTL.Target;
        }
       T.position=Target.transform.position+new Vector3(0,Distance,0);
 
    }
}
