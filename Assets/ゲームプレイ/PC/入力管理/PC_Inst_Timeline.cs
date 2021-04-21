using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    /// <summary>
    /// キャラクター個体ごとのインプット記録
    /// </summary>
public class PC_Inst_Timeline : MonoBehaviour
{

    /// <summary>
    ///入力イベント
    /// </summary>
    public struct Input_Event_st
    {
        /// <summary>
        ///入力タイプ(丸ボタン押し,右ボタン放し　等)
        /// </summary>
        public PC_Control.Input_st type;

        /// <summary>
        ///入力が起こったタイミング
        /// </summary>
        public float start;

        public Input_Event_st(PC_Control.Input_st TYPE, float START)
        {
            this.type = TYPE;
            this.start = START;
        }
    }
    /// <summary>
    ///イベント記録本体
    /// </summary>
    public List<Input_Event_st> EventList;

    void Start()
    {
        EventList = new List<Input_Event_st>();
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.E))
        {
            string st = "TYPES : COUNT : " + EventList.Count + "\n";
            int a = 0;
            foreach (var b in EventList)
            {
                st += a.ToString() + ":" + b.type.ToString() + ":" + b.start.ToString("F6");
                st += "\n";
                a++;
            }
            Debug.Log(st);

        }

    }




    /// <summary>
    /// 入力イベント作成
    /// </summary>
    /// <param name="type"></param>
    public void CreateEvent(PC_Control.Input_st type, float t)
    {
        int LatestIndex = 0;

        // 記録が空なら最初にイベント追加
        if (EventList.Count == 0)
        {
            EventList.Add(new Input_Event_st(type, t));
        }
        else
        {
            // 最新イベントよりも後にイベントが起こった場合
            if (EventList[EventList.Count - 1].start < t)
            {
                EventList.Add(new Input_Event_st(type, t));
            }
            else
            {
                //既にあるイベントを書き換える場合
                for (var i = 1; i < EventList.Count - 1; i++)
                {
                    if (EventList[i - 1].start < t && EventList[i + 1].start > t)
                    {
                        LatestIndex = i;
                        break;

                    }
                }
                
                //記録削除
                EventList.RemoveRange(LatestIndex, EventList.Count - LatestIndex);
                //記録追加
                EventList.Insert(LatestIndex, new Input_Event_st(type, t));

            }


        }


    }

    /// <summary>
    /// 次のイベントを探す。　渡したものが最新なら同じものを返す
    /// </summary>
    /// <param name="cur"></param>
    /// <returns></returns>
    public Input_Event_st FindNext(Input_Event_st cur)
    {
        if (EventList.Count > 1)
        {
            if (EventList.Count > EventList.IndexOf(cur) + 1)
            {
                return EventList[EventList.IndexOf(cur) + 1];
            }
            else
            {
                return EventList[EventList.Count - 1];
            }
        }
        return GetZero();
    }

/// <summary>
/// 最初のイベントを探す
/// </summary>
/// <returns></returns>
    public Input_Event_st GetZero()
    {
        if (EventList.Count > 0)
        {
            //            Debug.Log("RETZERO");
            return EventList[0];
        }
        else
        {
            return new Input_Event_st(PC_Control.Input_st.NULL, 0);
        }
    }




}
