using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Goal : GP_GimmickBase
{

    public Cam_EffectSet CamItem;

    bool running = false;
    public override void Event(bool state, PC_Base User)
    {
        if (state)
        {
            User.ResetInput();
            User.GetComponent<PC_Inst_Control>().NextInput.type = PC_Control.Input_st.Over;
            User.completed = true;

            if (User == PC_Control.TargetTL.GetComponent<PC_Base>())
            {
                if (!running)
                {
                    TL_TimeLineMng.mult = 1;
                    TL_TimeLineMng.ResetTimer();

                    FindObjectOfType<MG_StateManager>().AdvanceScene();

                    //            StartCoroutine("End");
                }
            }
            else
            {
                CamItem.Create(this.transform.position);
            }
        }
    }


    /*
       public float fadespeed;

        IEnumerator End()
        {
    running=true;
            while(TL_TimeLineMng.mult>0)
            {
                TL_TimeLineMng.mult-=fadespeed*Time.deltaTime;
                Debug.Log(TL_TimeLineMng.mult);
                yield return true;
            }
            TL_TimeLineMng.mult=1;
            TL_TimeLineMng.ResetTimer();

            FindObjectOfType<MG_StateManager>().AdvanceScene();
        running=false;
        }
    */
}
