using System;
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

   public Vector2 Targetpos;

    float timer;

    Transform T;

    private void Awake()
    {
        T=GetComponent<Transform>();
        an = GetComponent<Animator>();
        Targetpos = T.position;
        Debug.Log("Start");
        GetComponentInChildren<MeshRenderer>().enabled=false;
    }

    private void Update()
    {

        if(timer>TL_TimeLineMng.ctime)
        {
            activated=false;
        GetComponentInChildren<MeshRenderer>().enabled=false;

        moveend=false;
        }
        timer=TL_TimeLineMng.ctime;
/*
        if (Input.GetKeyDown(KeyCode.H))
        {
   

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

*/
    }

    void StartAtnimation()
    {

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PCs")
        {
            if(moveend)
            {
            GetComponentInChildren<MeshRenderer>().enabled=false;
             if (FindObjectOfType<CAM_Replay>().isactive)
            {

                Debug.Log("StartAnimation");
                StartAtnimation();
            }
            }
           
        }
    }

    public void Create(Vector2 startpos)
    {
        if (!activated)
        {
        T.position=startpos;
            StartPos = startpos;
            activated = true;
            Debug.Log("MoveStart");
            StartCoroutine("Move");
        }
    }
    public bool activated;
    Vector2 StartPos;
    public float speed = 1.0f;
public   bool moveend=false;
    IEnumerator Move()
    {
        GetComponentInChildren<MeshRenderer>().enabled=true;

        float lerp = 0;
        while (lerp < 1)
        {
            Debug.Log("MOVE:"+lerp.ToString("F4"));
            T.position = Vector2.Lerp(StartPos, Targetpos, lerp);
            lerp += Math.Max(speed * TL_TimeLineMng.delta,1.0f);
            yield return new  WaitForSeconds(1.0f/60.0f);
        }
        moveend=true;
    }

}
