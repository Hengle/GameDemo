using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitManager {

    private static List<Monster> monsterList = new List<Monster>();

    public static void AddMonster(Monster monster)
    {
        monsterList.Add(monster);
    }

    public static List<Monster> MonsterList { get { return monsterList; } }

}