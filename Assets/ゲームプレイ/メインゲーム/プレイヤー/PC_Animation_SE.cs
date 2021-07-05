using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_Animation_SE : MonoBehaviour
{
    //‚ ‚é‚­Œø‰Ê‰¹
    public AudioClip sound_Walk;
    //‚Í‚Ë‚éŒø‰Ê‰¹
   // public AudioClip sound_Jump;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //‚±‚ñ‚Û[‚Ë‚ñ‚Æ‚ğæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void WalkSE()
    {
        audioSource.PlayOneShot(sound_Walk);
    }
}
