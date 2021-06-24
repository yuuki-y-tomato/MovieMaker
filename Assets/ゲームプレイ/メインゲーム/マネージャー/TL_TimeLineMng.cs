using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 時間管理モジュール
/// </summary>

public class TL_TimeLineMng : MonoBehaviour
{

    /// <summary>
    /// 現時間
    /// </summary>
    static public float ctime;

    /// <summary>
    /// デルタ
    /// </summary>
    static public float delta;

    /// <summary>
    /// 時間のスピードを変える
    /// </summary>
    static public float mult = 1;


    /// <summary>
    /// タイムリミット
    /// </summary>
    public float max;
    /// <summary>


    /// <summary>
    /// リセット時少しの間ゲームが動かないようにする
    /// </summary>
    private float tst = 0;
    private static bool reset;

    // Update is called once per frame


    private static bool running;

    public static Action OnReset;

    private static TL_TimeLineMng self;

    void Start()
    {
        self=FindObjectOfType<TL_TimeLineMng>();
    }

    void Update()
    {

        if (reset)
        {
            reset = false;
            ctime = 0;
            tst = 0;
        }
     
        if (tst > 1)
        {

            delta = Time.deltaTime * mult;
            if (ctime < max)
            {
                if (running)
                {
                    ctime += delta;
                }
            }
        }
        tst += Time.deltaTime;

        if (Input.GetKey(KeyCode.Z))
        {
            mult = 0.5f;

        }
        else
        {
            mult = 1;
        }

    }

    public static void run(bool state)
    {
        running = state;
    }

    public static void ResetTimer()
    {
        reset = true;
        OnReset?.Invoke();
    }
    public static float GetTimelim()
    {
        return self.max;
    }

}
