using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    // Start is called before the first frame update

    public Material mat;
    public LineRenderer lr;
    public Material matinst;
    void Start()
    {
      matinst=  Instantiate(mat);
        lr.material=matinst;
    }

    // Update is called once per frame
    void Update()
    {
        matinst.SetFloat("_time", TL_TimeLineMng.ctime);
        float dist = Vector3.Distance(lr.GetPosition(0), lr.GetPosition(1));
        if (dist > 0)
        {
            mat.SetFloat("_Repeat", 1.0f / dist);
        }
    }
}
