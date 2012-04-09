namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Web;

    public class AssemblyUtil
    {
        public const string COMPANY = "Devv";
        public const string COPYRIGHT = "Copyright 2011, Devv.com";
        public const string TRADEMARK = "http://devv.com/";

        private AssemblyUtil()
        {
        }

        public static AppTypeEnum GetAppType()
        {
            if (!string.IsNullOrEmpty(HttpRuntime.AppDomainAppId))
            {
                return AppTypeEnum.AspNet;
            }
            return AppTypeEnum.WindowsForms;
        }

        public static string GetCurrentCultureLanguage()
        {
            return Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
        }

        public static string GetCurrentCultureRegion()
        {
            string name = Thread.CurrentThread.CurrentUICulture.Name;
            if (name.Contains("-"))
            {
                return name.Substring(3, 2).ToLower();
            }
            return string.Empty;
        }

        public static string GetFriendlyVersion(Assembly objAssembly)
        {
            Version version = objAssembly.GetName().Version;
            return (Conversions.ToString(version.Major) + "." + Conversions.ToString(version.Minor) + "." + Conversions.ToString(version.Build));
        }
    }
}
