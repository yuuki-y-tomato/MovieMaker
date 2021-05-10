using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_StateManager : MonoBehaviour
{
    // Start is called before the first frame update

public    List<PC_Base> CharacterOrder;
    public int Selection=0;

    void Start()
    {
        PC_Control.UpdateTarget(CharacterOrder[0]);
        FindObjectOfType<CAM_Gameplay>().UpdateTarget(CharacterOrder[0]);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            AdvanceScene();
        }
             if(Input.GetKeyDown(KeyCode.E))
        {
            RestartScene();
        }
    }


    public void RestartScene()
    {
        CharacterOrder[Selection].HardReset();

        foreach(var b in CharacterOrder)
        {
            b.ResetInput();
            b.completed=false;
        }


        PC_Control.TargetTL.EventList.Clear();
        TL_TimeLineMng.ResetTimer();
    }

  public  void AdvanceScene()
    {
        if(Selection<CharacterOrder.Count-1)
        {
       
         foreach(var b in CharacterOrder)
        {
            b.ResetInput();
            b.completed=false;

        }

        Selection++;
        PC_Control.UpdateTarget(CharacterOrder[Selection]);
        TL_TimeLineMng.ResetTimer();
        FindObjectOfType<CAM_Gameplay>().UpdateTarget(CharacterOrder[Selection]);
        }else
        {
       foreach(var b in CharacterOrder)
        {
            b.ResetInput();
            b.completed=false;

        }
        //    Debug.Log("sdhfaowssgfowag");
        FindObjectOfType<Camera>().GetComponent<CAM_Gameplay>().isactive=false;
        FindObjectOfType<Camera>().GetComponent<CAM_Replay>().isactive=true;
        TL_TimeLineMng.ResetTimer();
        }

    }

    
}
