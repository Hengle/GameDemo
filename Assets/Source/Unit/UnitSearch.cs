using UnityEngine;
using System.Collections.Generic;

public class UnitSearch  {
    public static readonly UnitSearch Instance = new UnitSearch();

	public MonsterAgent Search(Camp selfCamp, CampRelations campRelations)
    {
        List<MonsterAgent> monsterList = UnitManager.MonsterList;

        for (int i = monsterList.Count - 1; i >= 0; --i)
        {
            MonsterAgent monsterAgent = monsterList[i];
            if (!monsterAgent.IsValid())
            {
                monsterList.RemoveAt(i);
                continue;
            }

            Camp camp = monsterAgent.Camp;
            CampRelations relations = UnitCampRelations.GetRelations(selfCamp, camp);
            if (campRelations != relations)
            {
                continue;
            }

            return monsterAgent;
        }

        return null;
    }
}