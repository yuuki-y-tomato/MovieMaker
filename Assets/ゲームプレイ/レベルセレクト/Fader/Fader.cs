using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    //*reference to self
    static Fader reference;

    Material mat;
    Camera cam;
    public float speed;

    static bool running;
    private static IEnumerator Cor;
    public static bool closed;

    void Start()
    {
        reference = FindObjectOfType<Fader>();
        mat = GetComponent<SpriteRenderer>().material;
        cam = FindObjectOfType<Camera>();
        transform.position = cam.transform.position + new Vector3(0, 0, 0.1f);

    }


    public static void StartFade()
    {
        Cor = Toggle();
        reference.startco();
    }
    public void startco()
    {
        if (!running)
        {
            StartCoroutine(Cor);
        }
    }

    // Update is called once per frame
    public bool st;
    void Update()
    {
        transform.position = cam.transform.position + new Vector3(0, 0, 1);
        if (st)
        { Fader.StartFade(); st = false; }
    }

    static IEnumerator Toggle()
    {
        running = true;
        float deg;
        ///IN
        if (reference.mat.GetFloat("_Slider") > 0)//faded
        {
            deg = 1;
            for (; deg > 0;)
            {
                deg -= Time.deltaTime * reference.speed;
                reference.mat.SetFloat("_Slider", deg);
                yield return null;
            }
            closed = true;

        }
        else
        {
            deg = 0;

            for (; deg < 1.0f;)
            {
                deg += Time.deltaTime * reference.speed;
                reference.mat.SetFloat("_Slider", deg);
                yield return null;
            }
            closed = false;

        }
        running = false;

    }

}
