using Goap;

public class DamagerController {

	
    public static void Damage(GoapAgent attacker, GoapAgent target, int skillID)
    {
        SkillData skillData = TableTool.GetTableDataRow<SkillData>(TableType.Skill, skillID);
        if (skillData == null)
        {
            return;
        }

        target.Damage(skillData.damage);
    }
}
