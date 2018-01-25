using UnityEngine;

public class Game : MonoBehaviour {
    public static Game Instance;

    protected void Awake()
    {
        Instance = this;
        Init();
    }

    // Update is called once per frame
    void Update () {
        OnFrame();
	}

    private void Init()
    {
        AssetBundleManager.Instance.Init();
        LoadTableData.Instance.LoadAllTable();
        AccountManage.Instance.Init();
    }

    private void OnFrame()
    {
        AssetBundleManager.Instance.OnFrame();
        TimeFrameManage.OnFrame(Time.fixedDeltaTime);
        //DebugTest();
    }
}
