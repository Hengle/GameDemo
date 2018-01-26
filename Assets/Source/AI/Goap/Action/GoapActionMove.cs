using UnityEngine;
using Goap;

public class GoapActionMove : GoapAction {

	public GoapActionMove()
    {
        cost = 1;
    }

    public override void InitStatus()
    {
        base.InitStatus();

        preconditionsStatus.AddState(GoapCondition.hasEnemy, true);
        preconditionsStatus.AddState(GoapCondition.inAttackRange, false);

        effectsStatus.AddState(GoapCondition.inAttackRange, true);
    }

    public override bool CheckProceduralPrecondition()
    {
        //return goapGoal.target != null && !IsInRange();
        return true;
    }

    public override void Run()
    {
        base.Run();

        if (IsInRange())
        {
            Finish();
            return;
        }


        //if (goapGoal.target == null)
        //{
        //    Fail();
        //}

        //MoveController.instance.Move(goapGoal.transform, goapGoal.target.transform.position, 1);
    }

    protected override bool IsInRange()
    {
        float distance = 0;// Vector3.Distance(goapGoal.transform.position, goapGoal.target.transform.position);
        return distance <= 3;
    }
}
