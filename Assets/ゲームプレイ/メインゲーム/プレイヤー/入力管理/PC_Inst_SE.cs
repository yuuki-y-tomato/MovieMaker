using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Inst_SE : MonoBehaviour
{
    //Ç†ÇÈÇ≠å¯â âπ
    public AudioClip sound_Walk;
    //ÇÕÇÀÇÈå¯â âπ
    public AudioClip sound_Jump;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        //Ç±ÇÒÇ€Å[ÇÀÇÒÇ∆ÇéÊìæ
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            //Ç†ÇÈÇ≠å¯â âπ Ç»ÇÁÇ∑
            audioSource.PlayOneShot(sound_Walk);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ÇÕÇÀÇÈå¯â âπ Ç»ÇÁÇ∑
            audioSource.PlayOneShot(sound_Jump);
        }
    }
}
