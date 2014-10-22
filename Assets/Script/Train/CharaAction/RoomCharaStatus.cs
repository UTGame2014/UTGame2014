﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public partial class RoomCharaStatus : MonoBehaviour
{
    public float speed;
    public int monsterID;
    Transform myTransform;
    ICharaAction FearCom;
    ICharaAction NervousCom;
    ICharaAction LieCom;
    ICharaAction JumpCom;
    List<ICharaAction> ActionList { get; set; }
    CharaTrainSwing SwingCom;
    PlayerMonster myStatus;




    // Use this for initialization
    public void StartSetRoomCharaStatus()//起始設至怪獸狀態
    {
        SetCachedObj();
        CharaTrainStatusSetup();
        MovSetup();
    }
    void SetCachedObj()
    {
        ActionList = new List<ICharaAction>();
        myTransform = transform;
        myStatus = myTransform.GetComponent<PlayerMonster>();
        FearCom = myTransform.GetComponentInChildren<CharaTrainFear>();
        ActionList.Add(FearCom);
        NervousCom = myTransform.GetComponentInChildren<CharaTrainNervous>();
        ActionList.Add(NervousCom);
        LieCom = myTransform.GetComponentInChildren<CharaTrainLie>();
        ActionList.Add(LieCom);
        JumpCom = myTransform.GetComponentInChildren<CharaTrainJump>();
        ActionList.Add(JumpCom);
        SwingCom = myTransform.GetComponentInChildren<CharaTrainSwing>();
    }
    public void SwitchCharaAction(bool _on)
    {
        if (_on)
        {
            for (int i = 0; i < ActionList.Count; i++)
            {
                ((MonoBehaviour)ActionList[i]).enabled = true;
            }
            SwingCom.enabled = true;
        }
        else
        {
            for (int i = 0; i < ActionList.Count; i++)
            {
                ((MonoBehaviour)ActionList[i]).enabled = false;
            }
            SwingCom.enabled = false;
        }

    }

    void CharaTrainStatusSetup()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTimeFunction();
        StayTimeFunction();
        TouchTimerFunction();
    }
}