using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Switch : GP_Usable
{

    [Header("Instantiate用")]
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

    [Header("線")]
    public float speed;
    public float linemul = 1;
    public float LineSize = 0.5f;
    [Header("線ターゲット")]
    public List<GP_MovingPlatform> Targets;


    // Start is called before the first frame update
    void Start()
    {
        sprite.sprite = inactive_sp;
        linemat = new List<Material>();
        this.tag = "Usable";
        lines = new List<LineRenderer>();



        if (Showline)
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                lines.Add(Instantiate(LineBase));
                linemat.Add(Instantiate(LineMatBase));
                lines[i].SetPosition(1, this.transform.position);
                lines[i].SetPosition(0, Targets[i].T.position);


                lines[i].material = linemat[i];

            }
        }
    }

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
                    //* 線座標
                    lines[i].SetPosition(1, transform.position + new Vector3(0, 0, 1));
                    lines[i].SetPosition(0, Targets[i].PlatformCenter.transform.position);
                  
                    //* シェーダーアニメーション
                    linemat[i].SetFloat("_Repeat", 2.0f / Vector3.Distance(lines[i].GetPosition(0), lines[i].GetPosition(1)));
                    linemat[i].SetFloat("_time", TL_TimeLineMng.ctime * linemul);
                 
                    //*線太さ
                    lines[i].startWidth = LineSize;
                    lines[i].endWidth = LineSize;
                }
            }
            else
            {
                for (int i = 0; i < Targets.Count; i++)
                {
                    lines[i].SetPosition(0, new Vector3(-1000000, 0, 0));
                    lines[i].SetPosition(1, new Vector3(-1000000, 0, 0));
                }
            }
        }
    }
}
