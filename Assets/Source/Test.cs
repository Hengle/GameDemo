using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < 1; ++i)
            {
                Create();
            }
        }
	}

    private void Create()
    {
        // dige_ziyuan
        AssetPool.Instance.Build.LoadAsset<GameObject>("dige_ziyuan", LoadBuildingModel, new object[] {  }, true);
    }

    private void LoadBuildingModel(HandlerParam handlerParam)
    {
        if (handlerParam.assetObj == null)
        {
            return;
        }

        GameObject go = Instantiate(handlerParam.assetObj) as GameObject;
        go.name = "dige";
    }
}
