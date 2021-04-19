using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_TimeMeter : MonoBehaviour
{
    private Slider slider;
    private float localT;
    
  private void  Start() 
    {

     slider=   GetComponentInChildren<Slider>();

     slider.value=0;
    }

    private void Update() 
    {
        localT=TL_TimeLineMng.ctime+0.00001f;
       slider.value=localT/TL_TimeLineMng.Max_acc;
        


    }

}
