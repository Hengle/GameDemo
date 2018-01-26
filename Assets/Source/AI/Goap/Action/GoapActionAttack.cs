using UnityEngine;
using Goap;

public class GoapActionAttack : GoapAction {

	public GoapActionAttack()
    {
        cost = 5;
    }

    public override void InitStatus()
    {
        base.InitStatus();

        preconditionsStatus.AddState(GoapCondition.hasEnemy, true);
        preconditionsStatus.AddState(GoapCondition.hasUsableSkill, true);
        preconditionsStatus.AddState(GoapCondition.inAttackRange, true);

        effectsStatus.AddState(GoapCondition.attackEnemy, true);
    }

    public override bool CheckProceduralPrecondition()
    {
        return true;
    }

    public override void Run()
    {
        base.Run();

        //if (goapGoal.target == null)
        //{
        //    Fail();
        //    return;
        //}

        //if (goapGoal.GetType() == typeof(Person))
        //{
        //    Person person = (Person)goapGoal;
        //    person.AddFood(1);

        //    if (person.FoodEnougth())
        //    {
        //        Finish();
        //    }
        //}
    }
}