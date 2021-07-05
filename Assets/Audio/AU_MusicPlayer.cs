using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_MusicPlayer : MonoBehaviour
{
    Clapper clapper;
    AudioSource aus;
    public AudioClip Ready;
    public AudioClip GP;
    public float FadeinDuration = 1.5f;

    void Start()
    {
        clapper = FindObjectOfType<Clapper>();
        aus = GetComponent<AudioSource>();
        aus.clip = Ready;
        aus.Play();
    }

   bool fadeintrrupt;
    // Update is called once per frame
    void Update()
    {
        if (MG_StateManager.state == MG_StateManager.States.Ready)
        {
            if (aus.clip != Ready)
            {
                aus.clip = Ready;
                aus.Play();
                fadeintrrupt = false;
                aus.volume = 0;
                StartCoroutine("FadeIn");

            }
            if (clapper.rot > 0.25 && aus.volume > 0.01)
            {
                aus.volume = 1 - (3 * (clapper.rot / clapper.rotmax));
                fadeintrrupt = true;
            }

        }
        if (MG_StateManager.state == MG_StateManager.States.Gameplay)
        {
            if (aus.clip != GP)
            {
                fadeintrrupt = false;

                aus.clip = GP;
                aus.Play();
                aus.volume = 0;

                StartCoroutine("FadeIn");

            }
        }
    }

    IEnumerator FadeIn()
    {
        float time = 0;
        while (time < 1 && !fadeintrrupt)
        {
            time += Time.deltaTime / FadeinDuration;
            aus.volume = time;
            yield return null;

        }


    }

}
