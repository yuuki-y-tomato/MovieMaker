using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Apply Animation effect to camera on activation
/// PLACE IT AS MANAGER
/// </summary>
public class Cam_EffectPlayer : MonoBehaviour
{
    // Start is called before the first frame update

  Transform IntendedCoordinates;

  CAM_Replay camref;

    Transform EffectOffset;
    Camera Cam;

  
    private void Start() {
      camref=FindObjectOfType<Camera>().GetComponent<CAM_Replay>();

      
    }

  Vector3 defpos;
    public void DispatchEffect(Cam_EffectSet E)
    {

        EffectOffset=E.transform;
        defpos=EffectOffset.transform.position;
        playing=true;


     

        //Cam = FindObjectOfType<Camera>();
        //StartCoroutine("PlayAnimationSet");
    }
    /*
    IEnumerator PlayAnimationSet(Cam_EffectSet E)
    {

    }
*/
public bool playing=false;
    private void Update() {
    if(playing)
    {
      camref.EffectOffset=EffectOffset.position;
    }
    }

}
