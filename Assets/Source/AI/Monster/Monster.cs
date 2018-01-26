using Goap;

public class Monster : GoapGoal {

    private float hp = 100;

    protected override void Start()
    {
        base.Start();

        SetGoal(GoapCondition.attackEnemy, true);
        SetGoal(GoapCondition.inAttackRange, true);
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
        {
            target = UnitSearch.Instance.Search(Camp, CampRelations.Enemy);
        }
    }

    protected override void SetActions()
    {
        GoapActionAttack goapActionAttack = new GoapActionAttack(this);
        goapActionList.Add(goapActionAttack);

        GoapActionMove goapActionMove = new GoapActionMove(this);
        goapActionList.Add(goapActionMove);
    }

    public override GoapStatus GetWorldStatus()
    {
        return base.GetWorldStatus();
    }

    protected override void UpdateStatus()
    {
        worldStats.AddState(GoapCondition.hasEnemy, (target != null));
        worldStats.AddState(GoapCondition.hasUsableSkill, false);
        worldStats.AddState(GoapCondition.inAttackRange, false);
    }

    public Camp Camp { get; set; }

    public bool IsValid()
    {
        return hp > 0;
    }
}
