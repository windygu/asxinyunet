namespace Devv.Core.Utils
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Web;

    public class SessionUtil
    {
        private SessionUtil()
        {
        }

        public static object GetSession(string name)
        {
            return HttpContext.Current.Session[name];
        }

        public static bool GetSession(string name, bool defaultValue)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(GetSession(name));
            if (objectValue == null)
            {
                return defaultValue;
            }
            return Convert.ToBoolean(RuntimeHelpers.GetObjectValue(objectValue));
        }

        public static DateTime GetSession(string name, DateTime defaultValue)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(GetSession(name));
            if (objectValue == null)
            {
                return defaultValue;
            }
            return Convert.ToDateTime(RuntimeHelpers.GetObjectValue(objectValue));
        }

        public static int GetSession(string name, int defaultValue)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(GetSession(name));
            if (objectValue == null)
            {
                return defaultValue;
            }
            return Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue));
        }

        public static string GetSession(string name, string defaultValue)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(GetSession(name));
            if (objectValue == null)
            {
                return defaultValue;
            }
            return objectValue.ToString();
        }

        public static void SetSession(string name, object value)
        {
            HttpContext.Current.Session[name] = RuntimeHelpers.GetObjectValue(value);
        }
    }
}
