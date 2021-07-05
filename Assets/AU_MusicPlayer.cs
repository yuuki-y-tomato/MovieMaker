using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_MusicPlayer : MonoBehaviour
{
    Clapper clapper;

    AudioSource aus;
    public AudioClip Ready;
    public AudioClip GP;

    void Start()
    {
        clapper = FindObjectOfType<Clapper>();
        aus = GetComponent<AudioSource>();
        aus.clip = Ready;
        aus.Play();
    }


    // Update is called once per frame
    void Update()
    {
        if (MG_StateManager.state == MG_StateManager.States.Ready)
        {
            if (aus.clip != Ready)
            {
                aus.clip = Ready;
                aus.Play();

            }
            if (clapper.rot > 0.25 && aus.volume > 0.01)
            {
                aus.volume = 1 - (3 * (clapper.rot / clapper.rotmax));
            }

        }
        if (MG_StateManager.state == MG_StateManager.States.Gameplay)
        {
            if (aus.clip != GP)
            {

                aus.clip = GP;
                aus.Play();
                aus.volume = 1;
            }
        }
    }
}
