using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TL_EntityMng : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// ///* THIS OBJECT MOVES ENTITIES ACCORDING TO TIMELINE
    /// </summary>

    //*
    //* REQUIREMENTS
    //* INTERFACE TO ENTITIES
    //* 
    //*
    //* HOW:
    //* FIND CURRENTLY ACTIVE AND CURRENT/NEXT INPUT
    //* APPLY EVENT(MOVE/JUMP) TO THE TARGET
    //*
    //*
    //*


    private struct PC_Interface
    {
      public  PC_Inst_Control inst;
      public Transform T;

      public string type;

   public PC_Interface(Transform t, PC_Inst_Control par,string name)
    {
        this.T=t;
        this.inst=par;
        this.type=name;
    }

    }

    List<PC_Interface> Inst_Interface;

    void Start()
    {
    Inst_Interface=new List<PC_Interface>();
    List<PC_Inst_Control> Temp=new List<PC_Inst_Control>();
//* GET EVERY TIMELINE RELATED ENTITY
    Temp.AddRange(FindObjectsOfType<PC_Inst_Control>());

//* CREATE INTERFACE
    foreach(var b in Temp)
    {
        Inst_Interface.Add(new PC_Interface(b.GetComponentInParent<Transform>(),b,b.name));
    }


    } 

    // Update is called once per frame
    void Update()
    {






    }



}

