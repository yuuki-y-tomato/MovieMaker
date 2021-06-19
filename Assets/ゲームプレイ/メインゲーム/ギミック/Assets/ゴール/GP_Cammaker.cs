using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Cammaker : GP_GimmickBase
{

    public Cam_EffectSet CamItem;

    bool running = false;
    public bool isGoal;    

    public override void Event(bool state, PC_Base User)
    {

        if (state)
        {
            User.ResetInput();
            User.GetComponent<PC_Inst_Control>().NextInput.type = PC_Control.Input_st.Over;
            User.completed = true;

            if (User == PC_Control.TargetTL.GetComponent<PC_Base>())
            {
                if (!running&&isGoal)
                {
                    TL_TimeLineMng.mult = 1;
                    TL_TimeLineMng.ResetTimer();

                    FindObjectOfType<MG_StateManager>().AdvanceScene();

                    //            StartCoroutine("End");
                }
            }
            else
            {
                CamItem.Create(this.transform.position,User);
            }
        }
    }


}
