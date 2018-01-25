using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrameWork;

/// <summary>
/// 主城
/// </summary>
public class SceneCastle : SceneBase
{
    public static bool m_isFirstLogin = false;
    public SceneCastle() : base(SceneEnum.Castle)
    {
    }

    public override void StartLoading()
    {

    }

    public override void OnEnter()
    {
        LoadInitUI();
    }

    public override void OnDestroy()
    {
    }

    // 加载初始化UI
    private void LoadInitUI()
    {
        if (!m_isFirstLogin)
        {
            return;
        }
        m_isFirstLogin = false;
    }
}