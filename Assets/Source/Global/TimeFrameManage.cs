using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeFrameManage{

    private static float m_time = 0;
    private const float m_interval = 1;

    public static void OnFrame(float time)
    {
        m_time += time;
        if (m_time < m_interval)
        {
            return;
        }

        m_time = 0;

        EventManage.Instance.DispachEvent((int)EventHandlerID.TimeFrame, 0);
    }
}