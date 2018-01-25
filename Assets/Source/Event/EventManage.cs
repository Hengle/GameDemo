using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventHandlerID
{
    None              = 10000,

    LoginResponse     = 10002,  // 登录附带消息
    SelectCreateBuild = 10003,  // 选择新建建筑
    TimeFrame         = 10004,  // 时间帧率
    QueueChange       = 10005,  // 队列变化
    ResourceChange    = 10006,  // 资源变化
    UserProfileChange = 10007,  // 角色信息变化
    UserItemChange    = 10008,  // 道具数据变化
    BuildChange       = 10009,  // 建筑变化
    ResourceCollect   = 10010,  // 收资源

    ShowLogin         = 11001,  // 登录面板

}

public delegate void EventHandler(int type, object data);

public class EventManage {

    private static EventManage instance = null;

    private Dictionary<int, EventHandler> m_dicHandler = new Dictionary<int, EventHandler>();

    public static EventManage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManage();
            }
            return instance;
        }
    }

    private EventManage()
    {
        m_dicHandler = new Dictionary<int, EventHandler>();
    }

    /// <summary>
    /// 注册事件监听
    /// </summary>
    /// <param name="_type">事件类型</param>
    /// <param name="_eventHandler">监听者</param>
    public void AddEventListener(int _type, EventHandler _eventHandler)
    {
        if (!m_dicHandler.ContainsKey(_type))
        {
            EventHandler eventHandler = null;
            m_dicHandler[_type] = eventHandler;
        }
        m_dicHandler[_type] += _eventHandler;
    }

    /// <summary>
    /// 移除对 type 的监听
    /// </summary>
    /// <param name="_type">事件类型</param>
    public void RemoveEventLister(int _type)
    {
        if (m_dicHandler.ContainsKey(_type))
        {
            m_dicHandler[_type] = null;
        }
    }

    /// <summary>
    /// 移除 type 事件中的 lister
    /// </summary>
    /// <param name="_type">事件类型</param>
    /// <param name="_eventHandler">监听者</param>
    public void RemoveEventLister(int _type, EventHandler _eventHandler)
    {
        if (!m_dicHandler.ContainsKey(_type))
        {
            return;
        }
        m_dicHandler[_type] -= _eventHandler;
    }

    /// <summary>
    /// 清空所有监听
    /// </summary>
    private void ClearEventLister()
    {
        m_dicHandler.Clear();
    }

    /// <summary>
    /// 派发事件
    /// </summary>
    /// <param name="_type">事件类型</param>
    /// <param name="_data">数据</param>
    public void DispachEvent(int _type, object _data)
    {
        if (!m_dicHandler.ContainsKey(_type))
        {
            return;
        }

        if (m_dicHandler[_type] == null)
        {
            return;
        }
        m_dicHandler[_type](_type, _data);
    }
}

