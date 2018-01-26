using UnityEngine;
using System.Collections.Generic;

public class UnitSearch  {
    public static readonly UnitSearch Instance = new UnitSearch();

	public Monster Search(Camp selfCamp, CampRelations campRelations)
    {
        List<Monster> monsterList = UnitManager.MonsterList;

        for (int i = monsterList.Count - 1; i >= 0; --i)
        {
            Monster monster = monsterList[i];
            if (!monster.IsValid())
            {
                monsterList.RemoveAt(i);
                continue;
            }

            Camp camp = monster.Camp;
            CampRelations relations = UnitCampRelations.GetRelations(selfCamp, camp);
            if (campRelations != relations)
            {
                continue;
            }

            return monster;
        }

        return null;
    }
}