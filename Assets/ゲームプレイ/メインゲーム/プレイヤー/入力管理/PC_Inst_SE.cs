using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Inst_SE : MonoBehaviour
{
    //���邭���ʉ�
    public AudioClip sound_Walk;
    //�͂˂���ʉ�
    public AudioClip sound_Jump;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        //����ہ[�˂�Ƃ��擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            //���邭���ʉ� �Ȃ炷
            audioSource.PlayOneShot(sound_Walk);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�͂˂���ʉ� �Ȃ炷
            audioSource.PlayOneShot(sound_Jump);
        }
    }
}
