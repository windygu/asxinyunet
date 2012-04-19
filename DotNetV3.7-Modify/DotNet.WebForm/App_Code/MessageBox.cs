//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.UI;

public static class MessageBox
{
    #region public static void ShowAlert(string message) 显示消息，不需要确认
    /// <summary>
    /// 弹出消息
    /// </summary>
    /// <param name="message"></param>
    public static void ShowAlert(string message)
    {
        Page page = (Page)System.Web.HttpContext.Current.Handler;
        message = "<script>alert('" + message + "');</script>";
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", message);
            
    }
    #endregion

    #region public static void ShowAlert(string message,string url) 显示消息，不需要确认，并跳转到url
    /// <summary>
    /// 弹出消息，并跳转到url
    /// </summary>
    /// <param name="message"></param>
    /// <param name="url"></param>
    public static void ShowAlert(string message, string url)
    {
        Page page = (Page)System.Web.HttpContext.Current.Handler;
        message = "<script>alert('" + message + "');location='" + url + "';</script>";
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", message);
    }
    #endregion

    #region public static void ShowAlert(string message, string url, bool isRedirect) 弹出消息，自定义是否跳转到url
    /// <summary>
    /// 弹出消息，自定义是否跳转到url
    /// </summary>
    /// <param name="message"></param>
    /// <param name="url"></param>
    /// <param name="isRedirect"></param>
    public static void ShowAlert(string message, string url, bool isRedirect)
    {
        if (isRedirect)
            ShowAlert(message, url);
        else
            ShowAlert(message);
    }
    #endregion

    #region public static void ShowConfirmAlert(string message, string confirmurl,bool closeWindow=false) 弹出确认消息，跳转到url
    /// <summary>
    /// 弹出确认消息，跳转到url
    /// </summary>
    /// <param name="message"></param>
    /// <param name="confirmurl"></param>
    public static void ShowConfirmAlert(string message, string confirmurl, bool closeWindow = false)
    {
        Page page = (Page)System.Web.HttpContext.Current.Handler;
        message = "<script Language=Javascript>if( confirm('" + message + "') ) {document.location.href='" + confirmurl +
                  "'; } else { window.history.back(); }";
        
         if (closeWindow)
            message += " window.close();";
        message+="</script>";
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", message);
    }
    #endregion

    #region public static void ShowConfirmAlert(string message, string confirmurl, string cancelurl,bool closeWindow=false)弹出确认消息，根据用户选择跳转到不同的url
    /// <summary>
    /// 弹出确认消息，根据用户选择跳转到不同的url
    /// </summary>
    /// <param name="message"></param>
    /// <param name="confirmurl"></param>
    public static void ShowConfirmAlert(string message, string confirmurl, string cancelurl,bool closeWindow=false)
    {
        Page page = (Page)System.Web.HttpContext.Current.Handler;
        message = "<script Language=Javascript>if( confirm('" + message + "') ) {document.location.href='" + confirmurl +
                  "'; } else { document.location.href='" + cancelurl + "' }";
        if (closeWindow)
            message += " window.close();";
        message+="</script>";
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", message);
    }
    #endregion
    
    #region public static void Redirect(string url) url跳转
    /// <summary>
    /// url跳转
    /// </summary>
    /// <param name="url"></param>
    public static void Redirect(string url)
    {
        Page page = (Page)System.Web.HttpContext.Current.Handler;
        if(url==null||url.Length<1)
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "跳转地址不能为空。");
        else
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script>location='" + url + "';</script>");
    }
    #endregion
 }