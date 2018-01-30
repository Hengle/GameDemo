using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UIFrameWork;
using Goap;

public class HpControllerPanel : UIBase {
    public static HpControllerPanel instance = null;

    private string[] hpNames = new string[] { "HpSliderBlue", "HpSliderRed" };
    private Dictionary<string, Transform> hpDic = new Dictionary<string, Transform>();

    private Dictionary<string, Queue<Transform>> hpQueueDic = new Dictionary<string, Queue<Transform>>();

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void GetData()
    {
        
    }

    protected override void GetView()
    {
        for (int i = 0; i < hpNames.Length; ++i)
        {
            Transform hpTr = ToolsComponent.FindChildCom<Transform>(transform, hpNames[i]);
            if (hpTr != null)
            {
                hpDic[hpNames[i]] = hpTr;
            }
        }
    }

    public override void RefreshFixed()
    {
        
    }

    public void GetHp(GoapAgent goapAgent)
    {
        string hpName = string.Format("HpSlider{0}", Enum.GetName(typeof(Camp), goapAgent.Camp));

        if (!hpQueueDic.ContainsKey(hpName))
        {
            hpQueueDic[hpName] = new Queue<Transform>();
        }

        Transform hpTr = null;
        if (hpQueueDic[hpName].Count <= 0)
        {
            GameObject newHpGo = Instantiate(hpDic[hpName].gameObject) as GameObject;
            newHpGo.name = hpName;
            hpTr = newHpGo.transform;
            ToolsComponent.AddChild(transform, hpTr);
        }
        else
        {
            hpTr = hpQueueDic[hpName].Dequeue();
        }

        hpTr.gameObject.SetActive(true);
        SetHpData(hpTr, goapAgent);
    }

    private void SetHpData(Transform hpTr, GoapAgent goapAgent)
    {
        Hp hp = hpTr.GetComponent<Hp>();
        hp.SetAgent(goapAgent);
    }

    public void ReleaseHp(Transform hpTr)
    {
        hpQueueDic[hpTr.name].Enqueue(hpTr);
        hpTr.gameObject.SetActive(false);
    }
}