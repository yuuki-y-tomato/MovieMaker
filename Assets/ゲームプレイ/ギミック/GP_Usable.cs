using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Usable : MonoBehaviour
{
    // Start is called before the first frame update
    public Material LineMatBase;
    List<Material> linemat;
    void Start()
    {

        linemat = new List<Material>();
        this.tag = "Usable";
        lines = new List<LineRenderer>();
        if (Showline)
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                lines.Add(Instantiate(Base));
                linemat.Add(Instantiate(LineMatBase));
                lines[i].SetPosition(1, transform.position);
                lines[i].SetPosition(0, Targets[i].transform.position);
                lines[i].material = linemat[i];

            }
            tpos = new Vector3[Targets.Count];
        }


    }
    public LineRenderer Base;
    List<LineRenderer> lines;
    public bool Showline;

    public bool isactive = false;

    //   public GP_GimmickBase Target;

    public List<GP_GimmickBase> Targets; PC_Base LastUser;
    virtual public void Event(bool state)
    {

    }
    public float speed;
    Vector3[] tpos;
    public float linemul = 1;
    void Update()
    {
        foreach (var b in Targets)
        {
            b.Event(isactive, LastUser);
        }
        if (Showline && lines.Count > 0)
        {
            if (isactive)
            {

                for (int i = 0; i < Targets.Count; i++)
                {
                    //  tpos[i]+=((Targets[i].transform.position-transform.position).normalized)*speed*Time.deltaTime;

                    lines[i].SetPosition(1, transform.position);
                    lines[i].SetPosition(0, Targets[i].transform.position);
                    linemat[i].SetFloat("_Repeat", 2.0f / Vector3.Distance(lines[i].GetPosition(0), lines[i].GetPosition(1)));
                    linemat[i].SetFloat("_time", TL_TimeLineMng.ctime * linemul);
                }
            }
            else
            {
                for (int i = 0; i < Targets.Count; i++)
                {
                    tpos[i] = new Vector3();
                    lines[i].SetPosition(0, new Vector3(-1000000, 0, 0));
                    lines[i].SetPosition(1, new Vector3(-1000000, 0, 0));
                }
            }

        }

        //        Target.Event(isactive,LastUser);
    }

    public void Dispatch(bool state, PC_Base User)
    {
        isactive = state;

        LastUser = User;




    }






}
