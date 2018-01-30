using Goap;
using UnityEngine.UI;
using UnityEngine;

public class Hp : ViewController
{ 
    private GoapAgent goapAgent;
    private Follow follow = null;

    private Slider slider = null;

    private float hp = 0;
    private void Awake()
    {
        GetView();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(hp - goapAgent.Hp) > 1)
        {
            SetHp();
        }

        if (goapAgent == null || !goapAgent.IsAlive())
        {
            follow.SetPos(new Vector3(0, 1000, 0));
            HpControllerPanel.instance.ReleaseHp(transform);
        }
    }

    public void SetAgent(GoapAgent goapAgent)
    {
        this.goapAgent = goapAgent;
        Transform hpTarget = ToolsComponent.FindChildCom<Transform>(goapAgent.transform, "Hp");
        follow.SetTarget(hpTarget);
    }

    protected override void GetView()
    {
        follow = ToolsComponent.GetComponent<Follow>(transform);
        slider = ToolsComponent.FindChildCom<Slider>(transform, "Slider");
    }

    protected override void GetData()
    {
        
    }

    public override void RefreshFixed()
    {
        
    }

    public override void RefreshUI()
    {
        base.RefreshUI();
    }

    private void SetHp()
    {
        hp = goapAgent.Hp;
        slider.value = (goapAgent.Hp * 1.0f) / goapAgent.NpcData.hp;
    }
}
