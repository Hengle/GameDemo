using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public enum TableType
{
    /// <summary>
    /// 建筑属性
    /// </summary>
    BuildingData,
    /// <summary>
    /// 建筑描述
    /// </summary>
    BuildingDesData,
    /// <summary>
    /// 区域表
    /// </summary>
    CityAreaData,
    /// <summary>
    /// 地格默认建筑表
    /// </summary>
    CityDefault,
    /// <summary>
    /// 多语言文本
    /// </summary>
    LanguageData,
    /// <summary>
    /// 资源表
    /// </summary>
    Resource,
    None,
}

public class TableDefine
{
    private readonly static string building             = "build";
    private readonly static string building_des         = "building_des";
    private readonly static string cityArea             = "city_area";
    private readonly static string cityDefault          = "city_default";
    private readonly static string language             = "language";
    private readonly static string resource             = "resource";

    private static Dictionary<string, object> ObjectDic = new Dictionary<string, object>();

    private static Dictionary<TableType, string> TableTypeDic = new Dictionary<TableType, string>();
    static TableDefine()
    {
        ObjectDic.Clear();
        ObjectDic[building]                         = new BuildData();
        TableTypeDic[TableType.BuildingData]        = building;

        ObjectDic[building_des]                     = new BuildingDesData();
        TableTypeDic[TableType.BuildingDesData]     = building_des;

        ObjectDic[cityArea]                         = new CityAreaData();
        TableTypeDic[TableType.CityAreaData]        = cityArea;

        ObjectDic[cityDefault]                      = new CityDefaultData();
        TableTypeDic[TableType.CityDefault]         = cityDefault;

        ObjectDic[language]                         = new LanguageData();
        TableTypeDic[TableType.LanguageData]        = language;

        ObjectDic[resource]                         = new ResourceData();
        TableTypeDic[TableType.Resource]            = resource;
    }

    public static object GetTableType(string tableName)
    {
        object obj = null;
        if (ObjectDic.TryGetValue(tableName, out obj))
        {
            Type t = obj.GetType();
            object newobj = Activator.CreateInstance(t, true);//根据类型创建实例
            return newobj;
        }

        return obj;
    }

    public static string GetTableName(TableType tableTpye)
    {
        string tableName = string.Empty;
        if (TableTypeDic.TryGetValue(tableTpye, out tableName))
        {
            return tableName;
        }

        return tableName;  
    }
}