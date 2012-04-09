namespace Utils
{
    using System;
    using System.IO;
    using System.Web;

    /// <summary><para>　</para>
    /// 类名：常用工具类——网络相关类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>　==============以下为服务器信息==================</para><para>　GetServerName：获取站点服务器名称</para><para>　GetServerRootPath：获取站点根目录</para><para>　GetServerIP：获取站点服务器ＩＰ地址</para><para>　GetServerDoMain：获取站点服务器域名</para><para>　GetServerNetVersion：获取站点服务器.NET框架版本</para><para>　GetServerOsVersion：获取站点服务器操作系统</para><para>　GetServerIIS：获取站点服务器ＩＩＳ环境</para><para>　GetServerSitePort：获取站点服务器站点协议</para><para>　GetServerSiteProtocol：获取站点服务器站点端口</para><para>　GetServerScriptTimeOut：获取站点服务器脚本超时时间</para><para>　GetServerDateTime：获取站点服务器当前时间</para><para>　GetServerJDPath：获取站点服务器虚拟目录绝对路径</para><para>　GetServerTranslatedPath：获取站点服务器执行文件绝对路径</para><para>　CheckServeIsSupportHTTPS：获取站点服务器是否支持HTTPS</para><para>　GetServerSessionCount：获取站点服务器SESSION总数</para><para>　GetServerApplicationCount：获取站点服务器Application总数</para><para>　CheckServerIsSupportJMail：检测服务器是否支持JMail</para><para>　CheckServerIsSupportPersitesMail：检测服务器是否支持Persites邮件</para><para>　CheckServerIsSupportLyfUpload：检测服务器是否支持LyfUpload上传</para><para>　CheckServerIsSupportADOConnection：检测服务器是否支持ADO数据连接</para><para>　CheckServerIsSupportFSO：检测服务器是否支持FSO</para><para>　CheckServerIsSupportCDONTS：检测服务器是否支持CDONTSMail</para><para>　ShowAllServerVariablesInfo：显示所有的服务器ServerVariables信息</para><para>　===============以下为客户端信息=================</para><para>　GetCliectIP：获取客户端IP地址</para><para>　GetClientServerVerion：客户端操作系统</para><para>　GetClientBrowserType：客户端浏览器类别</para><para>　GetClientBrowserVersion：客户端浏览器版本号</para><para>　CheckClientBrowserIsSupportVBScript：客户端浏览器是否支持VBScript</para><para>　CheckClientBrowserIsSupportMobileDevice：客户端浏览器是否能识别移动设备</para><para>　CheckClientBrowserIsSupportActiveX：客户端浏览器是否能支持ActiveX</para><para>　CheckClientBrowserIsSupportBackgroundSounds：客户端浏览器是否能支持背景音乐播放</para><para>　GetClientBrowserNetVersion：客户端浏览器NET框架版本</para><para>　CheckClientBrowserSupportCookies：客户端浏览器是否支持Cookies</para><para>　CheckClientBrowserSupportFrames：客户端浏览器是否支持HTML框架</para><para>　CheckClientBrowserSupportJavaApplets：客户端浏览器是否支持Java</para><para>　GetClientLanguage：获取客户端默认语言</para><para>　GetClientIP：获得当前页面客户端的IP[ +2 重载 ]</para></summary>
    public class NetWorkHelper
    {
        /// <summary>客户端浏览器是否能支持ActiveX</summary>
        /// <returns></returns>
        public static bool CheckClientBrowserIsSupportActiveX() { return HttpContext.Current.Request.Browser.ActiveXControls; }

        /// <summary>客户端浏览器是否能支持背景音乐播放</summary>
        /// <returns></returns>
        public static bool CheckClientBrowserIsSupportBackgroundSounds() { return HttpContext.Current.Request.Browser.BackgroundSounds; }

        /// <summary>客户端浏览器是否能识别移动设备</summary>
        /// <returns></returns>
        public static bool CheckClientBrowserIsSupportMobileDevice() { return HttpContext.Current.Request.Browser.IsMobileDevice; }

        /// <summary>客户端浏览器是否支持VBScript</summary>
        /// <returns></returns>
        public static bool CheckClientBrowserIsSupportVBScript() { return HttpContext.Current.Request.Browser.VBScript; }

        /// <summary>客户端浏览器是否支持Cookies</summary>
        /// <returns></returns>
        public static bool CheckClientBrowserSupportCookies() { return HttpContext.Current.Request.Browser.Cookies; }

        /// <summary>客户端浏览器是否支持HTML框架</summary>
        /// <returns></returns>
        public static bool CheckClientBrowserSupportFrames() { return HttpContext.Current.Request.Browser.Frames; }

        /// <summary>客户端浏览器是否支持Java</summary>
        /// <returns></returns>
        public static bool CheckClientBrowserSupportJavaApplets() { return HttpContext.Current.Request.Browser.JavaApplets; }

        /// <summary>获取站点服务器HTTPS支持</summary>
        /// <returns></returns>
        public static bool CheckServeIsSupportHTTPS()
        {
            bool flag = false;
            while (HttpContext.Current.Request.ServerVariables["HTTPS"] == "on")
            {
                flag = true;
                if (((uint) flag) - ((uint) flag) <= uint.MaxValue) return flag;
            }
            return flag;
        }

        /// <summary>检测服务器是否支持ADO数据连接</summary>
        /// <returns></returns>
        public static bool CheckServerIsSupportADOConnection() { return x0c436f9a8037f9b1("ADODB.Connection"); }

        /// <summary>检测服务器是否支持CDONTSMail</summary>
        /// <returns></returns>
        public static bool CheckServerIsSupportCDONTS() { return x0c436f9a8037f9b1("CDONTS.NewMail"); }

        /// <summary>检测服务器是否支持FSO</summary>
        /// <returns></returns>
        public static bool CheckServerIsSupportFSO() { return x0c436f9a8037f9b1("Scripting.FileSystemObject"); }

        /// <summary>检测服务器是否支持JMail</summary>
        /// <returns></returns>
        public static bool CheckServerIsSupportJMail() { return x0c436f9a8037f9b1("JMail.SmtpMail"); }

        /// <summary>检测服务器是否支持LyfUpload上传</summary>
        /// <returns></returns>
        public static bool CheckServerIsSupportLyfUpload() { return x0c436f9a8037f9b1("LyfUpload.UploadFile"); }

        /// <summary>检测服务器是否支持Persites邮件</summary>
        /// <returns></returns>
        public static bool CheckServerIsSupportPersitesMail() { return x0c436f9a8037f9b1("Persits.MailSender"); }

        /// <summary>客户端浏览器NET框架版本</summary>
        /// <returns></returns>
        public static string GetClientBrowserNetVersion() { return HttpContext.Current.Request.Browser.ClrVersion.ToString(); }

        /// <summary>客户端浏览器类别</summary>
        /// <returns></returns>
        public static string GetClientBrowserType() { return HttpContext.Current.Request.Browser.Browser.ToString(); }

        /// <summary>客户端浏览器版本号</summary>
        /// <returns></returns>
        public static string GetClientBrowserVersion() { return (HttpContext.Current.Request.Browser.Version.ToString() + HttpContext.Current.Request.Browser.MinorVersionString.ToString()); }

        /// <summary>获得当前页面客户端的IP</summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetClientIP()
        {
            string ip = string.Empty;
            ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            goto Label_0080;
        Label_0027:
            if (ip == null && 4 != 0)
            {
                if (0 != 0) goto Label_0045;
                if (4 == 0)
                {
                    if (-1 != 0) goto Label_0080;
                    goto Label_009B;
                }
            }
            else if (!(ip == string.Empty) && MathHelper.IsIP(ip)) return ip;
            return "0.0.0.0";
        Label_0045:
            if (ip == string.Empty) goto Label_006B;
            goto Label_0027;
        Label_0061:
            if (ip != null && 8 != 0) goto Label_0045;
        Label_006B:
            ip = HttpContext.Current.Request.UserHostAddress;
            goto Label_0027;
        Label_0080:
            if (ip != null && !(ip == string.Empty))
            {
                if (15 != 0) goto Label_0061;
                goto Label_0027;
            }
        Label_009B:
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            goto Label_0061;
        }

        /// <summary>获得当前页面客户端的IP，并以指定显示位数，其余显示为*号</summary>
        /// <param name="ShowLength">显示IP的位数，其它以*号代替</param>
        /// <returns></returns>
        public static string GetClientIP(int ShowLength)
        {
            string str = string.Empty;
            string clientIP = GetClientIP();
            if (!string.IsNullOrEmpty(clientIP)) str = GetClientIP(clientIP, ShowLength);
            return str;
        }

        /// <summary>将指定IP格式化：显示位数，其他显示为*号代替</summary>
        /// <param name="ClientIP">客户端IP</param>
        /// <param name="ShowLength">显示IP的位数，其它以*号代替</param>
        /// <returns></returns>
        public static string GetClientIP(string ClientIP, int ShowLength)
        {
            string[] strArray;
            int num;
            string str = string.Empty;
        Label_000B:
            if (!string.IsNullOrEmpty(ClientIP))
            {
                strArray = StringHelper.Split(ClientIP, ".");
                if (ShowLength >= 4) ShowLength = 4;
                goto Label_00DD;
            }
            if (8 != 0) return str;
            goto Label_005C;
        Label_001B:
            if ((((uint) num) | 2) == 0 || ((uint) num) > uint.MaxValue) goto Label_0061;
        Label_0045:
            return str.Substring(0, str.Length - 1);
        Label_005C:
            if (strArray == null) goto Label_001B;
        Label_0061:
            if (strArray.Length > 0)
            {
                num = 0;
                if (((uint) num) - ((uint) ShowLength) > uint.MaxValue) return str;
            }
            else
            {
                if (0xff == 0) goto Label_00DD;
                if (0 == 0) goto Label_0045;
                goto Label_001B;
            }
            while (true)
            {
                if (num >= strArray.Length) goto Label_0045;
                if (num >= ShowLength)
                    str = str + "*.";
                else
                    str = str + strArray[num] + ".";
                num++;
            }
        Label_00DD:
            if (ShowLength <= 0)
            {
                ShowLength = 0;
                goto Label_005C;
            }
            if (((uint) ShowLength) - ((uint) ShowLength) >= 0) goto Label_005C;
            goto Label_000B;
        }

        /// <summary>获取客户端默认语言</summary>
        /// <returns></returns>
        public static string GetClientLanguage() { return HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"]; }

        /// <summary>客户端操作系统</summary>
        /// <returns></returns>
        public static string GetClientServerVerion() { return HttpContext.Current.Request.Browser.Platform.ToString(); }

        /// <summary>获取站点服务器Application总数</summary>
        /// <returns></returns>
        public static int GetServerApplicationCount() { return HttpContext.Current.Application.Keys.Count; }

        /// <summary>获取站点服务器当前时间</summary>
        /// <returns></returns>
        public static string GetServerDateTime() { return DateTime.Now.ToString("F"); }

        /// <summary>获取站点服务器域名</summary>
        /// <returns></returns>
        public static string GetServerDoMain() { return HttpContext.Current.Request.ServerVariables["SERVER_NAME"]; }

        /// <summary>获取站点服务器ＩＩＳ环境</summary>
        /// <returns></returns>
        public static string GetServerIISVersion() { return HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"]; }

        /// <summary>获取站点服务器ＩＰ地址</summary>
        /// <returns></returns>
        public static string GetServerIP() { return HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]; }

        /// <summary>获取站点服务器名称</summary>
        /// <returns></returns>
        public static string GetServerName() { return HttpContext.Current.Server.MachineName; }

        /// <summary>获取站点服务器.NET框架版本</summary>
        /// <returns></returns>
        public static string GetServerNetVersion() { return Environment.Version.ToString(); }

        /// <summary>获取站点服务器操作系统</summary>
        /// <returns></returns>
        public static string GetServerOsVersion() { return Environment.OSVersion.ToString(); }

        /// <summary>获取站点服务器虚拟目录绝对路径</summary>
        /// <returns></returns>
        public static string GetServerPhysicalPath() { return HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"]; }

        /// <summary>获取站点根目录</summary>
        /// <returns></returns>
        public static string GetServerRootPath(string StrPath)
        {
            if (HttpContext.Current != null) return HttpContext.Current.Server.MapPath(StrPath);
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, StrPath);
        }

        /// <summary>获取站点服务器脚本超时时间</summary>
        /// <returns></returns>
        public static string GetServerScriptTimeOut() { return HttpContext.Current.Server.ScriptTimeout.ToString(); }

        /// <summary>获取站点服务器SESSION总数</summary>
        /// <returns></returns>
        public static int GetServerSessionCount() { return HttpContext.Current.Session.Keys.Count; }

        /// <summary>获取站点服务器站点端口</summary>
        /// <returns></returns>
        public static string GetServerSitePort() { return HttpContext.Current.Request.ServerVariables["SERVER_PORT"]; }

        /// <summary>获取站点服务器站点协议</summary>
        /// <returns></returns>
        public static string GetServerSiteProtocol() { return HttpContext.Current.Request.ServerVariables["Server_Protocol"]; }

        /// <summary>获取站点服务器执行文件绝对路径</summary>
        /// <returns></returns>
        public static string GetServerTranslatedPath() { return HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"]; }

        /// <summary>显示所有的服务器ServerVariables信息</summary>
        public static void ShowAllServerVariablesInfo()
        {
            foreach (string str in HttpContext.Current.Request.ServerVariables)
            {
                HttpContext.Current.Response.Write("<font color='blue'>" + str + "</font>：<font color='red'>" + HttpContext.Current.Request.ServerVariables[str] + "</font><br>");
            }
        }

        private static bool x0c436f9a8037f9b1(string x02ebdc12ebf86805)
        {
            bool flag = false;
            try
            {
                HttpContext.Current.Server.CreateObject(x02ebdc12ebf86805);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }
    }
}
