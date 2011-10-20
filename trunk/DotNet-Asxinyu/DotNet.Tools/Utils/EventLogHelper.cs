namespace Utils
{
    using System;
    using System.Diagnostics;

    /// <summary><para>　</para>
    /// 类名：常用工具类——系统日志类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　WriteEventLog：写入系统日志(２个方法重载)</para><para>　DelEventName：删除日志事件源分类</para></summary>
    public class EventLogHelper
    {
        /// <summary>删除日志事件源分类</summary>
        /// <param name="EventName">事件源名</param>
        /// <returns></returns>
        public static bool DelEventName(string EventName)
        {
            bool flag = false;
            try
            {
                if (EventLog.SourceExists(EventName))
                {
                    EventLog.DeleteEventSource(EventName, ".");
                    flag = true;
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>写入系统日志</summary>
        /// <param name="EventName">事件源名称</param>
        /// <param name="LogStr">日志内容</param>
        public static void WriteEventLog(string EventName, string LogStr)
        {
            try
            {
                if (!EventLog.SourceExists(EventName)) EventLog.CreateEventSource(EventName, EventName);
                EventLog.WriteEntry(EventName, LogStr);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>写入系统日志</summary>
        /// <param name="EventName">事件源名称</param>
        /// <param name="LogType">日志类型</param>
        /// <param name="LogStr">日志内容</param>
        public static void WriteEventLog(string EventName, string LogStr, EventLogEntryType LogType)
        {
            try
            {
                if (!EventLog.SourceExists(EventName)) EventLog.CreateEventSource(EventName, EventName);
                EventLog.WriteEntry(EventName, LogStr, LogType);
            }
            catch (Exception)
            {
            }
        }
    }
}
