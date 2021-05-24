using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : MonoBehaviour
{
    // Start is called before the first frame update

    public colcir L,R,B,B2;
    public bool l,r,b;

    // Update is called once per frame
    void Update()
    {
        l=L.state;
        r=R.state;
        b=(B.state||B2.state);
    }

    
}
