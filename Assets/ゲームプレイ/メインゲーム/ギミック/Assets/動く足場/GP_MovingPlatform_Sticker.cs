using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_MovingPlatform_Sticker : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
    //    Debug.Log("col");
        other.gameObject.transform.SetParent(this.transform, true);
    }

    void OnCollisionExit2D(Collision2D other)
    {
      //  Debug.Log("exit");

        other.gameObject.transform.parent = null;
    }
}
