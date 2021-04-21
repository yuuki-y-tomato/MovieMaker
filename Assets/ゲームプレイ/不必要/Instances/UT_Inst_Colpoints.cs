using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_Inst_Colpoints : MonoBehaviour
{
    public bool colliding=false;


    private void OnCollisionEnter2D(Collision2D other) 
    {
        colliding=true;
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
            colliding=false;
    
    }
    
}