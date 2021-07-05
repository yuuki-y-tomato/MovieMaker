using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_Animation_SE : MonoBehaviour
{
    //あるく効果音
    public AudioClip sound_Walk;
    //はねる効果音
   // public AudioClip sound_Jump;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //こんぽーねんとを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void WalkSE()
    {
        audioSource.PlayOneShot(sound_Walk);
    }
}
