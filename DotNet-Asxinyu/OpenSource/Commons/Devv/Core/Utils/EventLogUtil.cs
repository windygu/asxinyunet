namespace Devv.Core.Utils
{
    using System;
    using System.Diagnostics;

    public class EventLogUtil
    {
        private EventLogUtil()
        {
        }

        public static void Write(string logName, string source, string text, EventLogEntryType eventType, int eventId)
        {
            if (!EventLog.Exists(logName) | !EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logName);
            }
            using (EventLog log = new EventLog(logName))
            {
                log.Source = source;
                log.WriteEntry(text, eventType, eventId);
            }
        }
    }
}
