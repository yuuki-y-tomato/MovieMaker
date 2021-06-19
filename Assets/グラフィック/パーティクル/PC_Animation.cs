using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Animation : MonoBehaviour
{
    // Start is called before the first frame update

    Transform T;
    Rigidbody2D rb;
    PC_Type_Moover PC;
    Animator an;
    void Start()
    {
        T = GetComponent<Transform>();

        PC = GetComponentInParent<PC_Type_Moover>();
        rb = GetComponentInParent<Rigidbody2D>();
        an = GetComponentInChildren<Animator>();
    }

    bool right;
    bool prev=true;

    bool moving;

    // Update is called once per frame
    void Update()
    {
        if (PC.Right)
        {
            moving=true;
            right = true;
        }
        if (PC.Left)
        {
             moving=true;
            right = false;
        }
        if (PC.Right && PC.Left)
        {
            if (rb.velocity.x > 0)
            {
                right = true;
            }
            if (rb.velocity.x < 0)
            {
                right = false;
            }
        }else
        {
             moving=false;
        }

        if (prev != right)
        {
            Vector3 buf = T.localScale;

            buf.x *= -1;
            T.localScale = buf;
            prev = right;
        }

        an.SetFloat("Speed",Math.Abs(PC.velo.x));


    }
}
