using System;
using System.Collections.Generic;
using System.Text;
public class ResourceData{
	/// <summary>
	///实体ID
	/// <summary>
	public int id {get;private set;}
	/// <summary>
	///实体类型
	/// <summary>
	public string entType {get;private set;}
	/// <summary>
	///名称
	/// <summary>
	public string name {get;private set;}
	/// <summary>
	///图标
	/// <summary>
	public string icon {get;private set;}
	/// <summary>
	///显示等级
	/// <summary>
	public int buildlevel {get;private set;}
	/// <summary>
	///初始值
	/// <summary>
	public int initNum {get;private set;}
	/// <summary>
	///资源产出间隔(秒)
	/// <summary>
	public int periodSecond {get;private set;}
}
