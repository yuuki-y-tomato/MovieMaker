using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum dir
    {
        Right, Left, Up, Down
    }
    static List<Bullet> isntances;
    static Bullet Base;
    private static bool initiated = false;

    public GR_EffectContainer Effect;

    void Start()
    {
        if (!initiated)
        {
            isntances = new List<Bullet>();
            Base = FindObjectOfType<Bullet>();
            initiated = true;
        }

    }
    static public void reset()
    {
        Debug.Log("Reset");
        foreach (var b in isntances)
        {
            Destroy(b.gameObject);
        }
        isntances.Clear();
    }
    public static void Create(dir direction, Vector3 pos, float speed)
    {

        isntances.Add(Instantiate(Base));
        isntances[isntances.Count - 1].Direction = direction;
        isntances[isntances.Count - 1].transform.position = pos;
        isntances[isntances.Count - 1].tag = "Death";
        isntances[isntances.Count - 1].speed = speed;
    }


    public dir Direction;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        switch (Direction)
        {
            case dir.Right:
                transform.position += new Vector3(speed, 0, 0) * TL_TimeLineMng.delta;
                break;
            case dir.Left:
                transform.position += new Vector3(-speed, 0, 0) * TL_TimeLineMng.delta;
                break;
            case dir.Up:
                transform.position += new Vector3(0, speed, 0) * TL_TimeLineMng.delta;
                break;
            case dir.Down:
                transform.position += new Vector3(0, -speed, 0) * TL_TimeLineMng.delta;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {


    if (other.gameObject.tag == "TileMap" || other.gameObject.tag == "PCs")
        {
            GR_EffectContainer.Create(Effect,transform);
            isntances.Remove(this);
            Destroy(this.gameObject);
        }
    }

}
