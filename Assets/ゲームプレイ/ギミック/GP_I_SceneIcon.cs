using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_I_SceneIcon : MonoBehaviour
{
    // Start is called before the first frame update

    
    public int id;    
    [Range(0,30)]
    public int start,end;

    public bool activated;
    public bool interactable;
    private Transform T;

    void Start()
    {
        T=GetComponent<Transform>();
        activated=false;

    }

    // Update is called once per frame
    void Update()
    {
        if(TL_TimeLineMng.ctime>start&&TL_TimeLineMng.ctime<end)
        {
            T.Rotate(new Vector3(0,4.0f,0));
            interactable=true;
        }else
        {
            interactable=false;
        }

        if(activated&&T.transform.position.y<1000)
        {
            T.transform.position+=new Vector3(0,2,0);
        }

    }
private void OnCollisionEnter2D(Collision2D other) {

Debug.Log("aaaa");
    if(other.gameObject.tag=="PCs"&&!activated&&interactable)
    {
            T.localScale*=0.5f;
        GP_SceneIcon.Activated_BC(id);
        activated=true;
        

    }
}
}
