using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POPUP_Controller : MonoBehaviour
{
    MG_StateManager.States prevstate;

    Transform T;
     Animator ac;
    Vector3 defpos;
    public bool hasAC;
    void Start()
    {
        prevstate = MG_StateManager.States.Ready;
        T = gameObject.transform;
        defpos = T.localPosition;
        if(hasAC)
        {
        ac=GetComponent<Animator>();
        }
        setpos();

    }
    void Update()
    {
        if (prevstate != MG_StateManager.state)
        {
            setpos();
        }
    }


    void setpos()
    {

        prevstate = MG_StateManager.state;
        if (prevstate == MG_StateManager.States.Ready)
        {
            if (hasAC)
            {
                ac.enabled = true;
            }
            T.localPosition = defpos;

        }
        else
        {
            if (hasAC)
            {
                ac.enabled = false;
            }
            Clapper.Setv(T, 108888888, 2);

        }

    }

}
