using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Usable : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        this.tag="Usable";
    }

    public bool isactive = false;

 //   public GP_GimmickBase Target;

    public List<GP_GimmickBase> Targets;
    PC_Base LastUser;
    virtual public void Event(bool state)
    {

    }
void Update()
{
    foreach(var b in Targets)
    {
        b.Event(isactive,LastUser);
    }
//        Target.Event(isactive,LastUser);
}

    public void Dispatch(bool state,PC_Base User)
    {
        isactive=state;
        LastUser=User;
    }



}
