using System.Collections;
using System.Collections.Generic;
using UnityEngine;



  [RequireComponent(typeof(Camera))]
  public class Cam_Overlay : MonoBehaviour 
  {

    public Material material;

    void OnRenderImage (RenderTexture source, RenderTexture destination) {
        material.SetTexture("_MainTex",source);
        Graphics.Blit(source, destination, material);
    }

    static Cam_Overlay Ref;
    void Start()
    {
        Ref=FindObjectOfType<Cam_Overlay>();
    }


    static void Set()
    {
            
    }

    [Range(0,1)]
    private float fade;
    private IEnumerator Fadein()
    {
        while(fade<1)
        {
            fade+=Time.deltaTime;
            material.SetFloat("_Fade",fade);
            yield return null;
        }
    }
  private IEnumerator FadeOut()
    {
        while(fade>0)
        {
            fade-=Time.deltaTime;
            material.SetFloat("_Fade",fade);
            yield return null;
        }
    }

  }


