using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_Goal_Use : GP_Usable
{
    GP_Goal Goal;
    void Start()
    {
        Goal = FindObjectOfType<GP_Goal>();
    }
    void Update()
    {
        Goal.Event(isactive, LastUser);
    }

}