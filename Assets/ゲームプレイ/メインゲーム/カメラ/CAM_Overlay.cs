using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_Overlay : MonoBehaviour
{
    public Material fademat;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        fademat.SetTexture("_MainTex",src);
        Graphics.Blit(src,dest,fademat);
    }
}
