using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colcir : MonoBehaviour
{

    void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger=true;
    }
    public bool state=false;
    void OnTriggerEnter2D(Collider2D other)
    {

        state=other.gameObject.tag=="TileMap"||other.gameObject.tag=="Turret";

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="TileMap"||other.gameObject.tag=="Turret")
        {
        state=false;
    }}

}
