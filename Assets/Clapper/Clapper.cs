using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clapper : MonoBehaviour
{
public    GameObject Top;
Transform Top_T;
public    GameObject Bottom;
    public List<TextMesh> Texts;

    private float rot;
    public float rotrate;
    public float rotmax;

public float smooth;
    void Start()
    {

    Top_T=Top.GetComponent<Transform>();

        Texts[0].text="Start";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            upd();
        }
        if(Input.GetKey(KeyCode.P))
        {
            rot=smin(rot+rotrate,rotmax,smooth);
            Debug.Log(rot);
        }else
        {
            rot-=rotrate*4.0f;
            rot= Math.Max(rot,0);
        }
      
        Top_T.rotation=Quaternion.Euler(0,0,-rot);
        
    }

    void upd()
    {
      Texts[0].text=  TL_TimeLineMng.ctime.ToString();
        Texts[0].GetComponent<Transform>().localScale=new Vector3(0.005f*Texts[0].text.Length,Texts[0].GetComponent<Transform>().localScale.y,1);
    }

 public   void UpdateGamestate(int id)
    {
        
        switch(id)
        {
            case 0:

            break;

        }
    }
    float smin(float val, float lim, float smooth)
    {

        float buf;
        buf = Math.Max(smooth - Math.Abs(val - lim), 0) / smooth;

        return Math.Min(val, lim) - buf * buf * smooth * 0.25f;


    }
}
