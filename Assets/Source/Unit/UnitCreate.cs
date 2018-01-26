using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreate
{
    public static readonly UnitCreate Instance = new UnitCreate();

    public void Create(string unitName, Camp camp, Vector3 position)
    {
        LoadCallBackHandler CallBack = delegate (HandlerParam p_handleParam)
        {
            LoadCallBack(p_handleParam);
        };
        AssetPool.Instance.Npc.LoadAsset<GameObject>(unitName, CallBack, new object[] { unitName, camp, position}, true);
    }

    private void LoadCallBack(HandlerParam p_handleParam)
    {
        if (p_handleParam.assetObj == null)
        {
            return;
        }

        object[] paramArr = (object[])p_handleParam.paramObj;

        string unitName = (string)paramArr[0];
        Camp camp = (Camp)paramArr[1];
        Vector3 position = (Vector3)paramArr[2];

        GameObject go = GameObject.Instantiate(p_handleParam.assetObj) as GameObject;
        go.transform.position = new Vector3(position.x, 0, position.z);
        go.name = unitName;

        Monster monster = go.GetComponent<Monster>();
        monster.Camp = camp;

        UnitManager.AddMonster(monster);
    }
}