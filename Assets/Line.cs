using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Base;

    public Vector2 start;
    public Vector2 end;

    public Transform st;
    public Transform en;


    public float density;
    public float mul;


    public List<GameObject> inst;

    void Start()
    {
        inst = new List<GameObject>();
    }
    public float timer=0;
    public float local=0;

    // Update is called once per frame
    public bool c;
    void Update()
    {
    //    timer += Time.deltaTime;
   
        for (int i = 0; i < inst.Count; i++)
        {
           // inst[i].transform.position = Vector2.Lerp(start, end, (((1.0f / density) * i) + (timer))%1.0f);
            inst[i].transform.position = Vector2.Lerp(st.position, en.position, (((1.0f / density) * i) + (timer))%1.0f);

        }

        if (c)
        {
            create();
            c = false;
        }
    }

    public void set()
    {
        local=-1;
    }

  public  void create()
    {

        if (inst.Count > 0)
        {
            foreach (var b in inst)
            {
                b.gameObject.SetActive(false);
            }
            inst.Clear();
        }
        density = Vector2.Distance(start, end) * mul;
        for (int i = 0; i < density; i++)
        {
            inst.Add(Instantiate<GameObject>(Base));
        }

    }
}
