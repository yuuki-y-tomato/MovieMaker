using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_Test : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController cc;
    void Start()
    {
        cc=GetComponent<CharacterController>();
    }
        Vector3 velo;
    public float speed;
    public float drag;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {velo.x+=speed;};
if(Input.GetKeyDown(KeyCode.A))
        {velo.x-=speed;};
        velo*=drag;
     cc.SimpleMove(velo);   
    }
}
