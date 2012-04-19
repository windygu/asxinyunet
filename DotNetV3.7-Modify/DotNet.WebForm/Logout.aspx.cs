//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Web.Security;

/// <summary>
/// LogOut
/// 退出系统
///
/// 修改纪录
///
///		2012-01-29 版本：1.0 JiRiGaLa 整理实现多系统的统一退出功能。
///
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2012-01-29</date>
/// </author>
/// </summary>
public partial class LogOut : System.Web.UI.Page
{
    #region public string ReturnURL 目的跳转页面
    public string ReturnURL
    {
        get
        {
            return this.txtReturnURL.Value;
        }
        set
        {
            this.txtReturnURL.Value = value;
        }
    }
    #endregion

    #region public void GetParameters() 获得页面参数
    /// <summary>
    /// 获得页面参数
    /// </summary>
    public void GetParameter()
    {
        if (Page.Request["ReturnURL"] != null)
        {
            this.ReturnURL = Page.Request["ReturnURL"];
        }
        else
        {
            if (Request.UrlReferrer != null)
            {
                // 不是本页面时
                if (!(Request.UrlReferrer.ToString().ToUpper().IndexOf("LOGON.ASPX") > 0))
                {
                    this.ReturnURL = Request.UrlReferrer.ToString();
                }
            }
        }
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        this.GetParameter();
        Utilities.Logout();
        // 重新定位到登录页面
        Response.Redirect(this.ReturnURL, true);
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DoPageLoad();
        }
    }
}