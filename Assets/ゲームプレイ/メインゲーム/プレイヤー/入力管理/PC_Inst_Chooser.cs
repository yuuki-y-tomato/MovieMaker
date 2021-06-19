using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグ用  
/// クリックした対象を入力対象とする
/// 
/// </summary>
public class PC_Inst_Chooser : MonoBehaviour
{
    Rigidbody2D rb;
    private void OnMouseDown() 
    {
        

        PC_Control.UpdateTarget(this.gameObject);
    }


}
