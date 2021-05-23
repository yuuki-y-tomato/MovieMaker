using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GR_EffectContainer : MonoBehaviour
{

    static List<GR_EffectContainer> ParticleList;
    private bool initialized = false;

    public List<ParticleSystem> Effects;
    public bool loop;
    public float duration;


    void Start()
    {
        GetComponentInChildren<SpriteRenderer>().enabled=false;

        if (!initialized)
        {
            ParticleList = new List<GR_EffectContainer>();
        }

        Effects = new List<ParticleSystem>();
        Effects.AddRange(GetComponentsInChildren<ParticleSystem>());
    }

    public void activate()
    {
        StartCoroutine("selfterminate");
    }

    void OnDestroy()
    {
        Effects.Clear();
    }


    static public void Create(GR_EffectContainer effect, Transform pos)
    {
        ParticleList.Add(Instantiate(effect,pos.position,new Quaternion()));
        ParticleList[ParticleList.Count-1].activate();
    }

    public static void ResetParticles()
    {
        List<GR_EffectContainer> ParticleList = new List<GR_EffectContainer>();
        ParticleList.AddRange(FindObjectsOfType<GR_EffectContainer>());
        foreach (var b in ParticleList)
        {
            foreach (var c in b.Effects)
            {
                c.Clear();
            }
        }
    }
    IEnumerator selfterminate()
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("Removed");
        ParticleList.Remove(this);
        Destroy(this.gameObject);
    }

}
