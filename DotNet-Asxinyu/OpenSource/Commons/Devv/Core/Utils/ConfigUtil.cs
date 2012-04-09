namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.Web;
    using System.Windows.Forms;
    using System.Xml;

    public class ConfigUtil
    {
        private ConfigUtil()
        {
        }

        public static string GetConfig(string key)
        {
            string str2 = ConfigurationManager.AppSettings[key];
            if ((str2 != null) && (str2.Length > 0))
            {
                return str2;
            }
            return string.Empty;
        }

        public static bool GetConfig(string strKey, bool blnDefault)
        {
            string str = ConfigurationManager.AppSettings[strKey];
            if ((str != null) && (str.Length > 0))
            {
                return DataUtil.TrueOrFalse(str);
            }
            return blnDefault;
        }

        public static DateTime GetConfig(string strKey, DateTime dtmDefault)
        {
            string s = ConfigurationManager.AppSettings[strKey];
            if ((s != null) && (s.Length > 0))
            {
                return DateTime.Parse(s);
            }
            return dtmDefault;
        }

        public static decimal GetConfig(string strKey, decimal decDefault)
        {
            string str = ConfigurationManager.AppSettings[strKey];
            if ((str != null) && (str.Length > 0))
            {
                return Convert.ToDecimal(str, CultureInfo.InvariantCulture);
            }
            return decDefault;
        }

        public static int GetConfig(string strKey, int intDefault)
        {
            string str = ConfigurationManager.AppSettings[strKey];
            if ((str != null) && (str.Length > 0))
            {
                return Convert.ToInt32(str, CultureInfo.InvariantCulture);
            }
            return intDefault;
        }

        public static string GetConfig(string key, string strDefault)
        {
            string str2 = ConfigurationManager.AppSettings[key];
            if ((str2 != null) && (str2.Length > 0))
            {
                return str2;
            }
            return strDefault;
        }

        public static ConnectionStringSettings GetConnectionString(string key)
        {
            ConnectionStringSettings settings2 = ConfigurationManager.ConnectionStrings[key];
            if (((settings2 != null) && (settings2.ConnectionString.Length > 0)) && (settings2.ProviderName.Length > 0))
            {
                return settings2;
            }
            return null;
        }

        public static void WriteConfig(string strKey, bool blnValue)
        {
            WriteConfig(strKey, blnValue.ToString());
        }

        public static void WriteConfig(string strKey, int intValue)
        {
            WriteConfig(strKey, intValue.ToString());
        }

        public static void WriteConfig(string strKey, string strValue)
        {
            string str;
            XmlDocument document = new XmlDocument();
            if (AssemblyUtil.GetAppType() == AppTypeEnum.AspNet)
            {
                str = HttpContext.Current.Request.PhysicalApplicationPath + "web.config";
            }
            else
            {
                str = Application.ExecutablePath + ".config";
            }
            try
            {
                document.Load(str);
                XmlNode newChild = document.SelectSingleNode("/configuration/appSettings/add[@key='" + strKey + "']");
                if (newChild == null)
                {
                    newChild = document.CreateElement("add");
                    XmlAttribute node = document.CreateAttribute("key");
                    node.Value = strKey;
                    newChild.Attributes.Append(node);
                    node = document.CreateAttribute("value");
                    node.Value = strValue;
                    newChild.Attributes.Append(node);
                    document.SelectSingleNode("/configuration/appSettings").AppendChild(newChild);
                }
                else
                {
                    newChild.Attributes["value"].Value = strValue;
                }
                document.Save(str);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                throw;
            }
        }
    }
}
