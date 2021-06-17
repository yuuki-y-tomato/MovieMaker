using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Switch : GP_Usable
{

    [Header("Instance Base")]
    public Material LineMatBase;
    List<Material> linemat;
    [Header("Sprites")]
    public Sprite inactive_sp;
    public Sprite active_sp;
    public SpriteRenderer sprite;


    [Header("Line")]
    public LineRenderer LineBase;
    public List<LineRenderer> lines;
    public bool Showline;

    [Header("LineSpeed")]
    public float speed;
    public float linemul = 1;

    [Header("Target Objects")]
    public List<GP_MovingPlatform> Targets;


    // Start is called before the first frame update
    void Start()
    {
        sprite.sprite = inactive_sp;
        linemat = new List<Material>();
        this.tag = "Usable";
        lines = new List<LineRenderer>();
        //Debug.Log(Targets.Count);
        
        
        
        if (Showline)
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                lines.Add(Instantiate(LineBase));
                linemat.Add(Instantiate(LineMatBase));
                lines[i].SetPosition(1, transform.position);
                lines[i].SetPosition(0, Targets[i].T.position);
                lines[i].material = linemat[i];

            }
            //      tpos = new Vector3[Targets.Count];
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var b in Targets)
        {
            b.Event(isactive, LastUser);
        }
        if (lines.Count > 0)
        {

            if (isactive)
            {

                for (int i = 0; i < Targets.Count; i++)
                {

                    //  tpos[i]+=((Targets[i].transform.position-transform.position).normalized)*speed*Time.deltaTime;

                    lines[i].SetPosition(1, transform.position);
                    lines[i].SetPosition(0, Targets[i].PlatformCenter.transform.position);
                    linemat[i].SetFloat("_Repeat", 2.0f / Vector3.Distance(lines[i].GetPosition(0), lines[i].GetPosition(1)));
                    linemat[i].SetFloat("_time", TL_TimeLineMng.ctime * linemul);
                }
            }
            else
            {
                for (int i = 0; i < Targets.Count; i++)
                {
                    //  tpos[i] = new Vector3();
                    lines[i].SetPosition(0, new Vector3(-1000000, 0, 0));
                    lines[i].SetPosition(1, new Vector3(-1000000, 0, 0));
                }
            }
        }
    }
}
