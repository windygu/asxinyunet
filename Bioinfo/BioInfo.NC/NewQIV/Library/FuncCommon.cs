using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace cn.buddy
{
    public class FuncCommon
    {

        public static string GetOutputTable(double[][] resultArray)
        {
            string output = "<table cellspacing=\"0\" cellpadding=\"0\" style=\"border-collapse:collapse; border:1px solid #333;\">";
            for (int i = 0; i < resultArray.Length; i++)
            {
                output += "<tr>";
                for (int j = 0; j < resultArray[i].Length; j++)
                {
                    output += "<td style=\"border:1px solid #333; padding-left:2px; width:200px; word-break:keep-all;\">";
                    output += resultArray[i][j].ToString();
                    output += "</td>";
                }
                output += "</tr>";
            }
            output += "</table>";

            return output;
        }

        public static void Alert(string msg)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">alert(\"" + msg + "\");</script>");
        }
        public static void Reload()
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.location=window.location;</script>");
        }
        public static void CloseWindow()
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.close();</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 弹出新窗口,url(新窗口相对本页路径)
        /// </summary>
        /// <param name="url"></param>
        public static void PopWindow(string url)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.open('" + url + "');</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 弹出新窗口,url:路径,width等参数如不需要设置，请传空字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="resizeable"></param>
        /// <param name="scrollbars"></param>
        /// <param name="status"></param>
        /// <param name="titlebar"></param>
        /// <param name="toolbar"></param>
        public static void PopWindow(string url, string width, string height, string top, string left, string resizeable, string scrollbars, string status, string titlebar, string toolbar)
        {
            string sFeatures = "";
            if (width != "") sFeatures += "width=" + width;
            if (height != "") sFeatures += "height=" + height;
            if (top != "") sFeatures += "top=" + top;
            if (left != "") sFeatures += "left=" + left;
            if (resizeable != "") sFeatures += "resizeable=" + resizeable;
            if (scrollbars != "") sFeatures += "scrollbars=" + scrollbars;
            if (status != "") sFeatures += "status=" + status;
            if (titlebar != "") sFeatures += "titlebar=" + titlebar;
            if (toolbar != "") sFeatures += "toolbar=" + toolbar;
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.open('" + url + "','','" + sFeatures + "');</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        ///  弹出新窗口,url:路径,width等参数如不需要设置，请传空字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="resizeable"></param>
        /// <param name="scrollbars"></param>
        /// <param name="status"></param>
        /// <param name="titlebar"></param>
        /// <param name="toolbar"></param>
        /// <param name="channelMode"></param>
        /// <param name="fullscreen"></param>
        public static void PopWindow(string url, string height, string width, string top, string left, string resizeable, string scrollbars, string status, string titlebar, string toolbar, string channelmode, string fullscreen)
        {
            string sFeatures = "";
            if (width != "") sFeatures += "width=" + width;
            if (height != "") sFeatures += "height=" + height;
            if (top != "") sFeatures += "top=" + top;
            if (left != "") sFeatures += "left=" + left;
            if (resizeable != "") sFeatures += "resizeable=" + resizeable;
            if (scrollbars != "") sFeatures += "scrollbars=" + scrollbars;
            if (status != "") sFeatures += "status=" + status;
            if (titlebar != "") sFeatures += "titlebar=" + titlebar;
            if (toolbar != "") sFeatures += "toolbar=" + toolbar;
            if (channelmode != "") sFeatures += "channelmode=" + channelmode;
            if (fullscreen != "") sFeatures += "fullscreen=" + fullscreen;
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.open('" + url + "','','" + sFeatures + "');</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 弹出新窗口,url:路径,bReplace:新打开的文档覆盖历史列表里的当前文档,width等参数如不需要设置，请传空字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="resizeable"></param>
        /// <param name="scrollbars"></param>
        /// <param name="status"></param>
        /// <param name="titlebar"></param>
        /// <param name="toolbar"></param>
        /// <param name="channelmode"></param>
        /// <param name="fullscreen"></param>
        /// <param name="bReplace"></param>
        public static void PopWindow(string url, string height, string width, string top, string left, string resizeable, string scrollbars, string status, string titlebar, string toolbar, string channelmode, string fullscreen, bool bReplace)
        {
            string sFeatures = "";
            if (width != "") sFeatures += "width=" + width;
            if (height != "") sFeatures += "height=" + height;
            if (top != "") sFeatures += "top=" + top;
            if (left != "") sFeatures += "left=" + left;
            if (resizeable != "") sFeatures += "resizeable=" + resizeable;
            if (scrollbars != "") sFeatures += "scrollbars=" + scrollbars;
            if (status != "") sFeatures += "status=" + status;
            if (titlebar != "") sFeatures += "titlebar=" + titlebar;
            if (toolbar != "") sFeatures += "toolbar=" + toolbar;
            if (channelmode != "") sFeatures += "channelmode=" + channelmode;
            if (fullscreen != "") sFeatures += "fullscreen=" + fullscreen;
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.open('" + url + "','','" + sFeatures + "','" + bReplace.ToString() + "');</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParentWindow()
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">opener.location.reload();</script>");
        }

        public static void GoBack()
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.history.go(-1);</script>");
            HttpContext.Current.Response.End();
        }
        public static void GoToURL(string url)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">window.location='" + url + "';</script>");
            HttpContext.Current.Response.End();
        }
        public static void TopGoToURL(string url)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\">top.location='" + url + "';</script>");
            HttpContext.Current.Response.End();
        }
        public static void Exit(string msg)
        {
            HttpContext.Current.Response.Write(msg);
            HttpContext.Current.Response.End();
        }
        public static void Exit()
        {
            HttpContext.Current.Response.End();
        }

        public static string FormatDateString(string str)
        {
            switch (str.Length)
            {
                case 4:
                    return str + "年";                   
                case 6:
                    return str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月";
                   
                case 8:
                    return str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月" + str.Substring(6, 2) + "日";
                   
                default:
                    return "";
                   
            }
        }

        public static string GetRndName()
        {
            Random rnd = new Random();
            string s = "";
            s += DateTime.Now.Year.ToString();
            if (DateTime.Now.Month < 10)
                s += "0";
            s += DateTime.Now.Month.ToString();
            if (DateTime.Now.Day < 10)
                s += "0";
            s += DateTime.Now.Day.ToString();
            if (DateTime.Now.Hour < 10)
                s += "0";
            s += DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute < 10)
                s += "0";
            s += DateTime.Now.Minute.ToString();
            if (DateTime.Now.Second < 10)
                s += "0";
            s += DateTime.Now.Second.ToString();
            if (DateTime.Now.Millisecond < 10)
                s += "00";
            else if (DateTime.Now.Millisecond < 100)
                s += "0";
            s += DateTime.Now.Millisecond.ToString();
            s += rnd.Next(10).ToString();
            s += rnd.Next(10).ToString();
            s += rnd.Next(10).ToString();
            s += rnd.Next(10).ToString();
            return s;
        }
        public static string GetRndName(string ext)
        {
            ext = ext.Replace(".", "");
            Random rnd = new Random();
            string s = "";
            s += DateTime.Now.Year.ToString();
            if (DateTime.Now.Month < 10)
                s += "0";
            s += DateTime.Now.Month.ToString();
            if (DateTime.Now.Day < 10)
                s += "0";
            s += DateTime.Now.Day.ToString();
            if (DateTime.Now.Hour < 10)
                s += "0";
            s += DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute < 10)
                s += "0";
            s += DateTime.Now.Minute.ToString();
            if (DateTime.Now.Second < 10)
                s += "0";
            s += DateTime.Now.Second.ToString();
            if (DateTime.Now.Millisecond < 10)
                s += "00";
            else if (DateTime.Now.Millisecond < 100)
                s += "0";
            s += DateTime.Now.Millisecond.ToString();
            s += rnd.Next(10).ToString();
            s += rnd.Next(10).ToString();
            s += rnd.Next(10).ToString();
            s += rnd.Next(10).ToString();
            s += "." + ext.ToString();
            return s;
        }

        public static string CutString(string str, int length)
        {
            int len = 0;
            int i;
            for (i = 0; i < str.Length; i++)
            {
                if (Char.Parse(str.Substring(i, 1)) > 'z')
                    len += 2;
                else
                    len += 1;
            }

            if (len <= length)
                return str;
            else
            {
                string r = "";
                len = 0;
                i = 0;
                for (i = 0; i < str.Length; i++)
                {
                    r += str.Substring(i, 1);

                    if (Char.Parse(str.Substring(i, 1)) > 'z')
                        len += 2;
                    else
                        len += 1;

                    if (len >= length - 3)
                    {
                        i = str.Length;
                        r += "...";
                    }
                }
                return r;
            }
        }

        public static string GetAppSetting(string appName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[appName].ToString();
        }
    }
}
