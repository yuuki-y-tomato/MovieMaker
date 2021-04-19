using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Inst_Chooser : MonoBehaviour
{
    Rigidbody2D rb;
    private void OnMouseDown() 
    {
        

        PC_Control.UpdateTarget(this.gameObject);
    }


}
