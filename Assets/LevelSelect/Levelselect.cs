using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelselect : MonoBehaviour
{
    // Start is called before the first frame update

    public Wheel wheel;
    public Material Strip;
   // public TextMesh text;
    public List<LevelInfo> LevelList;
    public Material LImage;
    public SpriteRenderer LevelImage;
    void Start()
    { text.text=" ";
        StripLength=0;
            Strip.SetFloat("_slider",StripLength);

        slideend=false;
    }
    bool slideend=false;
    public float sliderrate=1.0f;
    private float timer;
    // Update is called once per frame
    public TextMesh text;

float opacity;
int target=0;
    void Update()
    {
        if(wheel.ended&&!slideend)
        {
            StripLength+=0.015f;
            Strip.SetFloat("_slider",StripLength);
            slideend=(StripLength>1.0f);
        }
            timer+=Time.deltaTime*sliderrate;
            Strip.SetFloat("_time",timer);
        if(wheel.ended){
            LevelImage.sprite=LevelList[wheel.selection].LevelImage;
             text.text=LevelList[wheel.selection].LevelName;
        if(wheel.set&&opacity<0.9f&&target!=wheel.selection)
        {
            opacity=Math.Min(Time.deltaTime+opacity,1.0f);
            LImage.SetFloat("_Opacity",opacity);
            
        }
        else
        {
            target=wheel.selection;
            opacity=Math.Min(Time.deltaTime+opacity,1.0f);
            LImage.SetFloat("_Opacity",opacity);
            if(opacity<0.0015f)
            {
                    Debug.Log("aifwehiuu");
            }
        }
        }

    }

    float StripLength;



}
