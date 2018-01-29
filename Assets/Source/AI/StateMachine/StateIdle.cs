using Goap;

public class StateIdle : StateBase{

	public StateIdle(GoapAgent goapAgent) :base(StateEnum.Idle, goapAgent)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExecute()
    {
        base.OnExecute();

        if (!goapAgent.HasTarget)
        {
            goapAgent.Target = UnitSearch.Instance.Search(goapAgent.Camp, CampRelations.Enemy);
        }

        if (goapAgent.HasTarget)
        {
            if (goapAction != null)
            {
                goapAction.Fail();
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
