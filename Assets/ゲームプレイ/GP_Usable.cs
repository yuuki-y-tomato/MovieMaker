using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Usable : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isactive = false;
    
    public GP_GimmickBase Target;
    public PC_Base LastUser;
    virtual public void Event(bool state)
    {

    }
void Update()
{
        Target.Event(isactive,LastUser);
}

    public void Dispatch(bool state,PC_Base user)
    {
        LastUser=user;
        isactive=state;

    }



}
