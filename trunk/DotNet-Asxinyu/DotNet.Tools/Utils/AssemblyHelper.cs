namespace Utils
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary><para>　</para>
    /// 类名：常用工具类——应用程序属性信息访问类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　GetAssemblyTitle：获取应用程序集的标题</para><para>　GetAssemblyProduct：获取应用程序产品名称</para><para>　GetAssemblyVersion：获取应用程序版本</para><para>　GetAssemblyDescription：获取应用程序说明</para><para>　GetAssemblyCopyright：获取应用程序版权信息</para><para>　GetAssemblyCompany：获取应用程序公司名称</para><para>　GetAssemblyAppFullName：获取应用程序显示名称</para></summary>
    public class AssemblyHelper
    {
        /// <summary>获取应用程序显示名称</summary>
        /// <returns></returns>
        public static string GetAssemblyAppFullName() { return Assembly.GetExecutingAssembly().FullName.ToString(); }

        /// <summary>获取应用程序公司名称</summary>
        /// <returns></returns>
        public static string GetAssemblyCompany()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (customAttributes.Length == 0) return "";
            return ((AssemblyCompanyAttribute) customAttributes[0]).Company;
        }

        /// <summary>获取应用程序版权信息</summary>
        /// <returns></returns>
        public static string GetAssemblyCopyright()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            while (customAttributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
        }

        /// <summary>获取应用程序说明</summary>
        /// <returns></returns>
        public static string GetAssemblyDescription()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (0 == 0 && customAttributes.Length != 0) return ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
            return "";
        }

        /// <summary>获取应用程序产品名称</summary>
        /// <returns></returns>
        public static string GetAssemblyProduct()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (customAttributes.Length == 0) return "";
            return ((AssemblyProductAttribute) customAttributes[0]).Product;
        }

        /// <summary>获取应用程序集的标题</summary>
        /// <returns></returns>
        public static string GetAssemblyTitle()
        {
            AssemblyTitleAttribute attribute;
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (customAttributes.Length > 0)
            {
                attribute = (AssemblyTitleAttribute) customAttributes[0];
                if (0 == 0)
                {
                    if (attribute.Title != "") goto Label_0018;
                }
                else if (15 != 0) goto Label_0018;
            }
            return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        Label_0018:
            return attribute.Title;
        }

        /// <summary>获取应用程序版本</summary>
        /// <returns></returns>
        public static string GetAssemblyVersion() { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
    }
}
