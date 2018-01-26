using System.Collections.Generic;
using Goap;

public class GoapActionManager : IAction
{
    private GoapAgent goapAgent;
    private GoapAction currentGoapAction = null;
    private List<GoapAction> goapActionList = new List<GoapAction>();

    public GoapActionManager(GoapAgent goapAgent)
    {
        this.goapAgent = goapAgent;
        GoapActionAttack goapActionAttack = new GoapActionAttack();
        SetActions(goapActionAttack);

        GoapActionMove goapActionMove = new GoapActionMove();
        SetActions(goapActionMove);
    }

    public void SetActions(GoapAction goapAction)
    {
        goapActionList.Add(goapAction);
    }

    public List<GoapAction> GetActions()
    {
        return goapActionList;
    }

    public void OnFrame()
    {
        if (currentGoapAction != null)
        {
            currentGoapAction.Run();
        }
        else
        {
            ChangeAction();
        }
    }

    private void ActionFinishCallBack(GoapAction goapAction)
    {
        EndAction(goapAction);
    }

    private void ActionFailCallBack(GoapAction goapAction)
    {
        EndAction(goapAction);
    }

    private void EndAction(GoapAction goapAction)
    {
        if (currentGoapAction != goapAction)
        {
            return;
        }

        ChangeAction();
    }

    private void ChangeAction()
    {
        currentGoapAction = goapAgent.GoapPlanManager.GetPerformerAction();
        if (currentGoapAction != null)
        {
            currentGoapAction.SetCallBack(ActionFinishCallBack, ActionFailCallBack);
        }
    }
}