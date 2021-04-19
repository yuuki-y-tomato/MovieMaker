using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_FC_IconFactory : MonoBehaviour
{

    //*RETURN SPRITE CORRESPONDING TO EVENT ID

    public Sprite[] Images;


    public Sprite GetImage(int id)
        {
           
            return Images[0];
        }  

}
