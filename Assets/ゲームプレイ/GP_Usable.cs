using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Usable : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isactive = false;

    public GP_GimmickBase Target;

    virtual public void Event(bool state)
    {

    }
void Update()
{
        Target.Event(isactive);
}

    public void Dispatch(bool state)
    {
        isactive=state;

    }



}
