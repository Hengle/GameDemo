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

        Debug.LogError("SkillID :" + skill.SkillData.id + "     " + skill.Index + "    " + goapAgent.name);
        
        base.OnEnter();
        float animationLength = goapAgent.AnimationManager.GetAnimationLength(stateAnimationDic[stateEnum]);
        endTime = Time.realtimeSinceStartup + animationLength;

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

        endTime = Time.realtimeSinceStartup + 10; // 放置当前还没推出，下一帧又执行
        if (goapAction != null)
        {
            goapAction.Finish();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
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