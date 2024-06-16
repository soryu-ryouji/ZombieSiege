﻿using System;
using System.Collections;
using System.Collections.Generic;
// using Script.FrameWork.MusicManager;
using UnityEngine;

public class Main : MonoBehaviour
{
    private static Main instance;
    public static Main Instance => instance;

    // 生成角色模型位置
    public Transform showRolePos;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.ShowPanel<BeginPanel>();
        // MusicManger.Instance.PlayMusic("Music/开始界面", DataManager.Instance.musicData.musicVolume, true);
    }
}