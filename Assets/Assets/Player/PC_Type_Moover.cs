using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Type_Moover : MonoBehaviour
{
    // Start is called before the first frame update

PC_Inst_Control cont_ref;
Transform T;

Vector3 Init_P;
    void Start()
    {
        cont_ref= GetComponent<PC_Inst_Control>();
        T=GetComponent<Transform>();
        Init_P=T.position;
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(cont_ref.Input_States[0]);
        switch(cont_ref.Input_States[0])
        {
            case 0:
                T.position+=new Vector3(1,0,0)*TL_TimeLineMng.delta;
            break;
        

        }


    }
}
