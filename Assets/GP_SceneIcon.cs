using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_SceneIcon : MonoBehaviour
{
    // Start is called before the first frame update


    List<GP_I_SceneIcon> SceneList;
    int nextEvent;

    float time;

    void Start()
    {

        

        SceneList=new List<GP_I_SceneIcon>();
        SceneList.AddRange(FindObjectsOfType<GP_I_SceneIcon>());

      for(int i=0;i<SceneList.Count;i++)
      {
      SceneList[i].id=i;
      }
    



    }



    void Update()
    {
                




     
    }


void UpdateEvent()
{
     
}

 static public void Activated_BC(int id)
    {

    }    


}
