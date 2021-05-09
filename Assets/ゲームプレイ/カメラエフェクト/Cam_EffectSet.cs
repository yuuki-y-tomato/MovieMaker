using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Store set of animations unique to Item
/// PLACE PER CAM ITEM, PLACED UNDER ITEM PREFAB
/// </summary>
public class Cam_EffectSet : MonoBehaviour
{

    ///*
    ///*    HOW TO USE
    ///*   1.CREATE A CLIP
    ///*   2.GOTO SCENEICON ANIMATION CONTROLLER
    ///*   3.CREATE A NEW LAYER AND A STATE WITH CLIP NAME
    ///*   4.CREATE A NEW STATE WITH CLIP IN IT
    ///*   5.CONNECT STATE WITH CLIPNAME WITH NEW STATE WITH ANIMATION IN IT 
    ///*
    ///*
    /// 



    public List<AnimationClip> AnimationSet;

    private Animator an;

    private void Start()
    {
        an = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            #region 
            //            GetComponent<Cam_EffectPlayer>().DispatchEffect(this);
            /*
                        an.Play("EffectPlay");
                        an.Play("EffectPlay 2");
            */
            //            an.SetLayerWeight(0,1);
            //            an.SetLayerWeight(1,0.5f);
            #endregion
            
            
             an.speed = TL_TimeLineMng.mult;
            
            float ratio = 1.0f / AnimationSet.Count;
            foreach (var b in AnimationSet)
            {
                an.SetLayerWeight(an.GetLayerIndex(b.name), ratio);
                Debug.Log(an.GetLayerWeight(an.GetLayerIndex(b.name)));
                
                an.Play(b.name);
           
            }

            FindObjectOfType<Cam_EffectPlayer>().DispatchEffect(this);

        }


    }



}
