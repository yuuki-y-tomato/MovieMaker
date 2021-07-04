using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC_Animation_SE : MonoBehaviour
{
    //���邭���ʉ�
    public AudioClip sound_Walk;
    //�͂˂���ʉ�
   // public AudioClip sound_Jump;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //����ہ[�˂�Ƃ��擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   public void WalkSE()
    {
        audioSource.PlayOneShot(sound_Walk);
    }
}
