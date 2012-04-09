namespace Utils
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary><para>　</para>
    /// 类名：常用工具类——消息Message类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>----------------------------------------------------------</para><para>　ShowMessage：转到Message.aspx，并显示错误信息</para><para>　Show：显示消息提示对话框</para><para>　ShowConfirm：控件点击 消息确认提示框</para><para>　ShowAndRedirect：显示消息提示对话框，并进行页面跳转</para><para>　ResponseScript：输出自定义脚本信息</para><para>　OpenWindow：弹出一个页面</para></summary>
    public class MessageHelper
    {
        /// <summary>控件点击 消息确认提示框</summary>
        /// <param name="Control">要点击的控件</param>
        /// <param name="msg">提示信息</param>
        public static void ClickBtnShowConfirm(WebControl Control, string msg) { Control.Attributes.Add("onclick", "return confirm('" + msg + "');"); }

        /// <summary>弹出一个页面</summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="Url">弹出页面地址及名称</param>
        /// <param name="Para">附带参数，没有则为null</param>
        public static void OpenWindow(Page page, string Url, string Para)
        {
            Url = Url + "?TempPara=" + DateTimeHelper.FileNameStr("", 2);
            if (!string.IsNullOrEmpty(Para)) Url = Url + "&" + Para;
            string script = "window.open('" + Url + "')";
            page.ClientScript.RegisterStartupScript(page.GetType(), "MyScript", script, true);
        }

        /// <summary>输出自定义脚本信息</summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(Page page, string script) { page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>" + script + "</script>"); }

        /// <summary>显示消息提示对话框</summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(Page page, string msg) { page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>"); }

        /// <summary>显示消息提示对话框，并进行页面跳转</summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(Page page, string msg, string url) { page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript'>alert('" + msg + "');window.location=\"" + url + "\"</script>"); }

        /// <summary>显示错误信息，并在指定时间后转到相应页面</summary>
        /// <param name="type">信息提示类型：Other为其它信息；Error为错误信息；Warning为警告信息；Success为成功信息</param>
        /// <param name="msg">信息提示信息</param>
        public static void ShowMessage(string type, string msg)
        {
            string url = string.Format("/Message.aspx?type={0}&msg={1}", type, msg);
            HttpContext.Current.Response.Redirect(url);
        }

        /// <summary>显示错误信息，并在指定时间后转到相应页面</summary>
        /// <param name="type">信息提示类型：Other为其它信息；Error为错误信息；Warning为警告信息；Success为成功信息</param>
        /// <param name="msg">信息提示信息</param>
        /// <param name="url">转到相应页面(经过URL编码后的字符串)</param>
        public static void ShowMessage(string type, string msg, string url)
        {
            string str = string.Format("/MessageRedirect.aspx?type={0}&msg={1}&url={2}", type, msg, EncyptHelper.UrlEncode(url));
            HttpContext.Current.Response.Redirect(str);
        }

        /// <summary>显示错误信息，并在指定时间后转到相应页面</summary>
        /// <param name="msgtype">信息提示类型：Other为其它信息；Error为错误信息；Warning为警告信息；Success为成功信息</param>
        /// <param name="msg">信息提示信息</param>
        /// <param name="url">转到相应页面(经过URL编码后的字符串)</param>
        public static void ShowMessage(MsgType msgtype, string msg, string url)
        {
            string str = string.Format("/MessageRedirect.aspx?type={0}&msg={1}&url={2}", msgtype, msg, EncyptHelper.UrlEncode(url));
            HttpContext.Current.Response.Redirect(str);
        }

        /// <summary>消息类型枚举</summary>
        public enum MsgType
        {
            Other,
            Error,
            Waning,
            Success
        }
    }
}
