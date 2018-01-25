using System;
using System.Collections.Generic;
using System.Text;
public class BuildData{
	/// <summary>
	///编号
	/// <summary>
	public int id {get;private set;}
	/// <summary>
	///实体类型
	/// <summary>
	public string entType {get;private set;}
	/// <summary>
	///建筑名称
	/// <summary>
	public string name {get;private set;}
	/// <summary>
	///等级
	/// <summary>
	public int level {get;private set;}
	/// <summary>
	///建筑类型
	/// <summary>
	public int type {get;private set;}
	/// <summary>
	///建筑要求
	/// <summary>
	public string entityLimits {get;private set;}
	/// <summary>
	///道具要求
	/// <summary>
	public string item {get;private set;}
	/// <summary>
	///粮食
	/// <summary>
	public int food {get;private set;}
	/// <summary>
	///木头
	/// <summary>
	public int wood {get;private set;}
	/// <summary>
	///石头
	/// <summary>
	public int stone {get;private set;}
	/// <summary>
	///铁矿
	/// <summary>
	public int iron {get;private set;}
	/// <summary>
	///时长s
	/// <summary>
	public int time {get;private set;}
	/// <summary>
	///建筑战力
	/// <summary>
	public int power {get;private set;}
	/// <summary>
	///领主经验
	/// <summary>
	public int exp {get;private set;}
	/// <summary>
	///拆除时长s
	/// <summary>
	public int destroyTime {get;private set;}
	/// <summary>
	///建筑效果
	/// <summary>
	public string entityEffects {get;private set;}
	/// <summary>
	///建造位置
	/// <summary>
	public string posAbles {get;private set;}
	/// <summary>
	///建筑模型
	/// <summary>
	public string shape {get;private set;}
	/// <summary>
	///最大数量
	/// <summary>
	public int maxNum {get;private set;}
	/// <summary>
	///下一级的建筑ID
	/// <summary>
	public int nextId {get;private set;}
	/// <summary>
	///资源产量
	/// <summary>
	public int resProduct {get;private set;}
	/// <summary>
	///资源存量
	/// <summary>
	public int resCapacity {get;private set;}
	/// <summary>
	///对应的资源实体ID
	/// <summary>
	public int resEntId {get;private set;}
}
