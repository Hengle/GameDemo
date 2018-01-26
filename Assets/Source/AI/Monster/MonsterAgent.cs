using UnityEngine;
using Goap;

public class MonsterAgent : GoapAgent {

    private MonsterAgent target;
    private float hp = 100;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Init()
    {
        base.Init();

        goapStateManager = new GoapStateManager(this);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Controller()
    {
        base.Controller();

        if (target == null)
        {
            target = UnitSearch.Instance.Search(Camp, CampRelations.Enemy);
        }
    }

    public Camp Camp { get; set; }

    public bool HasTarget { get { return target != null; } }

    public bool InAttackRange()
    {
        if (target == null)
        {
            return false;
        }

        float distance = Vector3.Distance(target.transform.position, transform.position);

        return distance < 3;
    }

    public bool IsValid()
    {
        return hp > 0;
    }
}