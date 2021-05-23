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

    public GameObject Sprite;

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;
        T = GetComponent<Transform>();
        Targetpos = T.position;
        Debug.Log("Start");
        //      GetComponentInChildren<MeshRenderer>().enabled = false;
        T.position = new Vector3(-100, -1000, 0);
      //  GetComponent<BoxCollider2D>().enabled = false;
        activated = false;
        Sprite.transform.localPosition = new Vector3(0, 0, 10);
    }

    private Vector3 asv3(Vector2 v)
    {
        return new Vector3(v.x, v.y, 0);
    }

    private void Update()
    {

        if (timer > TL_TimeLineMng.ctime)
        {
            activated = false;
            //GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponent<Animator>().enabled = false;

            moveend = false;
           // GetComponent<BoxCollider2D>().enabled = false;
            T.position = new Vector3(-100, -1000, 0);

        }
        timer = TL_TimeLineMng.ctime;


        if (Vector3.Distance(asv3(Targetpos), transform.position) < 0.01f)
        {
            moveend = true;
       //     GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        if (activated)
        {

            T.position += (asv3(Targetpos) - T.position) * speed;

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartAtnimation();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "PCs" && moveend&&maker!=other.gameObject)
        {
          //  Sprite.transform.localPosition = new Vector3(0, 0, 10);
                StartCoroutine("MoveUp");
                moveend=false;
            if (MG_StateManager.state == MG_StateManager.States.Replay)
            {
                StartAtnimation();

            }

        }
    }


    void StartAtnimation()
    {

        an = GetComponent<Animator>();
        GetComponent<Animator>().enabled = true;

        an.speed = TL_TimeLineMng.mult;

        float ratio = 1.0f / AnimationSet.Count;
        foreach (var b in AnimationSet)
        {
            an.SetLayerWeight(an.GetLayerIndex(b.name), ratio);
            Debug.Log(an.GetLayerWeight(an.GetLayerIndex(b.name)));

            an.Play(b.name);

        }

        FindObjectOfType<Cam_EffectPlayer>().DispatchEffect(this);
        an = null;

    }
    private GameObject maker;

    public void Create(Vector2 startpos,PC_Base user)
    {
        if (!activated)
        {
            maker=user.gameObject;
            Debug.Log(startpos);
            StartPos = startpos;
            transform.position = startpos;

            activated = true;
            //   GetComponentInChildren<MeshRenderer>().enabled = true;

            //Debug.Log("MoveStart"); 
            Sprite.transform.localPosition = new Vector3(0, 0, 0);

            StartCoroutine("Move");
        }
    }
    public bool activated;
    Vector2 StartPos;
    public float speed = 1.0f;
    public bool moveend = false;

    IEnumerator Move()
    {

        while (Vector3.Distance(T.position, StartPos) > 0.01f)
        {
            /*
                            Debug.Log("MOVE:" + lerp.ToString("F4"));
                            T.position = Vector2.Lerp(StartPos, Targetpos, lerp);
                            lerp += Math.Max(speed * TL_TimeLineMng.delta, 1.0f);
                            yield return new WaitForSeconds(1.0f / 60.0f);*/

            T.position = Clapper.lerp(T.position, StartPos, speed);

            yield return null;
        }
        moveend = true;
    }

    IEnumerator MoveUp()
    {
        float k=0;
        while(k<10)
        {
            
            Sprite.transform.localPosition=Clapper.lerp
            (Sprite.transform.localPosition,new Vector3(Sprite.transform.localPosition.x,1000,Sprite.transform.localPosition.z),speed);
            k+=Time.deltaTime;
            yield return null;
        }
    }



}
