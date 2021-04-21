using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_TL_inst_Icon : MonoBehaviour
{


    public float TLwidth;
    public RectTransform ParentPos;
    private RectTransform Pos;
    public PC_Inst_Timeline.Input_Event_st Event;

    void Start()
    {
 
    }
    public void init(PC_Inst_Timeline.Input_Event_st ev)
    {
        Event=ev; 
        //* GET TIMELINE SIZE
       TLwidth=ParentPos.sizeDelta.x;
        
        //*GET RATIO BETWEEN MAX AND EVENT START
        float range=Event.start/TL_TimeLineMng.Max_acc;

        Pos=GetComponent<RectTransform>();
        //* POSITION ITSELF
        Pos.position=new Vector3((TLwidth*range)-TLwidth/2,Pos.position.y,Pos.position.z);
        
        //*GET SPRITE
        GetComponent<Image>().sprite=DummyImageGetter((int)Event.type);
    }

    Sprite DummyImageGetter(int id)
    {
        
      return FindObjectOfType<UI_FC_IconFactory>().GetImage(id);
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
