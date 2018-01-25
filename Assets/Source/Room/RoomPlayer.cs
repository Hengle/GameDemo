using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// 房间中的玩家
/// </summary>
public class RoomPlayer
{
    // 阵营
    private Camp camp = Camp.Red;
    // 营地
    private Transform camping;

    private List<NpcData> npcDataList = new List<NpcData>();

    public RoomPlayer(Camp camp)
    {
        this.camp = camp;

        npcDataList = TableTool.GetTableData<NpcData>(TableType.Npc);
    }

    public void OnFrame()
    {
        GetCamping();

        time += Time.deltaTime;
        if (time > 5)
        {
            time = 0;
            CreateUnit();
        }
    }

    private float time = 0;

    private void CreateUnit()
    {
        if (camping == null)
        {
            return;
        }

        int value = UnityEngine.Random.Range(0, npcDataList.Count);
        NpcData npcData = npcDataList[value];
        Debug.LogError(value + "   " + npcData.prefab);
        AssetPool.Instance.Npc.LoadAsset<GameObject>(npcData.prefab, LoadCallBack, new object[] { }, true);
    }

    private void LoadCallBack(HandlerParam p_handleParam)
    {
        if (p_handleParam.assetObj == null)
        {
            return;
        }

        GameObject go = GameObject.Instantiate(p_handleParam.assetObj) as GameObject;
        go.transform.position = camping.position;
    }

    private void GetCamping()
    {
        if (camping == null)
        {
            string campingName = Enum.GetName(typeof(Camp), camp);
            GameObject campingObj = GameObject.Find(campingName);
            if (campingObj != null)
            {
                camping = campingObj.transform;
            }
        }
    }

    /// <summary>
    /// 阵营
    /// </summary>
    public Camp Camp { get { return camp; } }
}