using UnityEngine;

public class Skill  {

    private int skillID;
    private SkillData skillData;
    private float coolDown = 0;
    private int index = 0;

    public Skill(int skillID, int index)
    {
        this.skillID = skillID;
        this.index = index;

        Init();
    }
	
    private void Init()
    {
        skillData = TableTool.GetTableDataRow<SkillData>(TableType.Skill, skillID);
        if (skillData == null)
        {
            Debug.LogError("SkillData is null : " + skillID);
            return;
        }

        Reset();
    }

    public void Reset()
    {
        coolDown = skillData.coolDown;
    }

    public bool IsUseable()
    {
        return coolDown <= 0;
    }

    public void OnFrame()
    {
        coolDown -= Time.deltaTime;
    }

    public float Range()
    {
        return skillData != null ? skillData.attackRange : 0;
    }

    public SkillData SkillData { get { return skillData; } }

    public int Index { get { return index; } }
}