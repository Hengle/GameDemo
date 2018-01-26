﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class GoapStateManager : IGoal, IStatus
{
    private MonsterAgent monsterAgent;

    private GoapStatus worldStats = new GoapStatus();  // 外部环境状态
    private GoapStatus goalStatus = new GoapStatus();  // 要完成的目标
    
    public GoapStateManager(MonsterAgent monsterAgent)
    {
        this.monsterAgent = monsterAgent;

        SetGoal(GoapCondition.attackEnemy, true);
        SetGoal(GoapCondition.inAttackRange, true);
    }

    public void OnFrame()
    {
        UpdateStatus();
    }

    /// <summary>
    /// 设置目标
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="value"></param>
    public void SetGoal(GoapCondition condition, object value)
    {
        goalStatus.AddState(condition, value);
    }

    /// <summary>
    /// 获取目标
    /// </summary>
    /// <returns></returns>
    public GoapStatus GetGoalStatus()
    {
        return goalStatus;
    }

    public void UpdateStatus()
    {
        worldStats.AddState(GoapCondition.hasEnemy, monsterAgent.HasTarget);
        worldStats.AddState(GoapCondition.inAttackRange, monsterAgent.InAttackRange());
        worldStats.AddState(GoapCondition.hasUsableSkill, false);
    }

    public GoapStatus GetWorldStatus()
    {
        return worldStats;
    }
}
