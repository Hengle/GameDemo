using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitManager {

    private static List<MonsterAgent> monsterList = new List<MonsterAgent>();

    public static void AddMonster(MonsterAgent monsterAgent)
    {
        monsterList.Add(monsterAgent);
    }

    public static List<MonsterAgent> MonsterList { get { return monsterList; } }

}