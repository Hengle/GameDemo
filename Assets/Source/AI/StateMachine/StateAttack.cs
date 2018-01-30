using Goap;
using UnityEngine;

public class StateAttack : StateBase {
    private Skill skill = null;
    private float endTime = 0;

    public StateAttack(GoapAgent goapAgent) :base(StateEnum.Attack, goapAgent)
    {

    }

    public override void OnEnter()
    {
        skill = goapAgent.UseableSkill();

        base.OnEnter();
        float animationLength = goapAgent.AnimationManager.GetAnimationLength(stateAnimationDic[stateEnum]);
        endTime = Time.realtimeSinceStartup + animationLength;

        Debug.LogError("AnimName :" + stateAnimationDic[stateEnum] + "    " + animationLength);

        skill.Reset();
        goapAgent.AttackUseSkill = skill;
    }

    public override void OnExecute()
    {
        base.OnExecute();

        if (endTime > Time.realtimeSinceStartup)
        {
            return;
        }

        ResetTime();
        if (goapAction != null)
        {
            goapAction.Finish();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        ResetTime();
    }

    private void ResetTime()
    {
        endTime = Time.realtimeSinceStartup + int.MaxValue; // 放置当前还没推出，下一帧又执行
    }

    protected override string GetAnimationName()
    {
        if (skill.Index == 0)
        {
            return base.GetAnimationName();
        }
        string animName = string.Format("{0}{1}", base.GetAnimationName(), skill.Index);
        return animName;
    }
}