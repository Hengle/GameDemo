using System;
using System.Collections.Generic;
using System.Text;
public class CityDefaultData{
	/// <summary>
	///地格编号
	/// <summary>
	public int id {get;private set;}
	/// <summary>
	///地格可建造建筑
	/// <summary>
	public string building_list {get;private set;}
	/// <summary>
	///地格初始存在的建筑和等级
	/// <summary>
	public string building_default {get;private set;}
	/// <summary>
	///地格所属区域
	/// <summary>
	public int belong_area {get;private set;}
	/// <summary>
	///空地格显示美术资源
	/// <summary>
	public string plot {get;private set;}
	/// <summary>
	///建造选择界面的描述
	/// <summary>
	public string name {get;private set;}
}
